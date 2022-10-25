using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
	const float minPathUpdateTime = .2f;
	const float pathUpdateMoveThreshold = .5f;


    [Header("Unit Stats")]
	public int health = 100;
	public GameObject deathEffect;

	public Transform target;
	public float startSpeed = 5;
	private float speed = 10;
	public float turnSpeed = 5;
	public float turnDst = 0;
	public float stoppingDst = 1;

	private Enemy enemy;

	Path path;

    private void Start()
    {
		target = GameObject.Find("Target").transform;
		StartCoroutine(UpdatePath());
    }

    public void OnPathFound(Vector3[] waypoints, bool pathSuccessful)
	{
		if (pathSuccessful)
		{
			path = new Path(waypoints, transform.position, turnDst, stoppingDst);
			
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator UpdatePath()
    {
		if(Time.timeSinceLevelLoad < .3f)
			yield return new WaitForSeconds(.3f);
        
		PathRequestManager.RequestPath(new PathRequest(transform.position, target.position, OnPathFound));

		float sqrMoveThreshold = pathUpdateMoveThreshold * pathUpdateMoveThreshold;
		Vector3 targetPosOld = target.position;

        while (true)
        {
			if (Vector3.Distance(transform.position, target.position) <= 5f)
			{
				EndPath();
			}

			yield return new WaitForSeconds(minPathUpdateTime);
			if((target.position - targetPosOld).sqrMagnitude > sqrMoveThreshold)
            {
				PathRequestManager.RequestPath(new PathRequest(transform.position, target.position, OnPathFound));
				targetPosOld = target.position;
			}
			
		}
    }

	public void Slow(float slowPct, float slowTime)
    {
		float _slowTime = slowTime;
		_slowTime -= Time.deltaTime;
		if(_slowTime > 0)
        {
			speed *= slowPct;
        }
        else
        {
			speed = startSpeed;
        }
    }

	IEnumerator FollowPath()
	{
		bool followingPath = true;
		int pathIndex = 0;
		transform.LookAt(path.lookPoints[0]);
		float speedPercent = 1;

		while (followingPath)
		{
			
			Vector2 pos2D = new Vector2(transform.position.x, transform.position.z);
            while (path.turnBoundries[pathIndex].HasCrossedLine(pos2D))
            {
				if(pathIndex == path.finishLineIndex)
                {
					followingPath = false;
					break;
                }
                else
                {
					pathIndex++;
                }
            }
            if (followingPath)
            {
				if(pathIndex >= path.slowDownIndex && stoppingDst > 0)
                {
					speedPercent = Mathf.Clamp01(path.turnBoundries[path.finishLineIndex].DistanceFromPoint(pos2D) / stoppingDst);
					if(speedPercent < 0.01)
                    {
						followingPath = false;
                    }
				}
				Quaternion targetRotation = Quaternion.LookRotation(path.lookPoints[pathIndex] - transform.position);
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
				transform.Translate(Vector3.forward * Time.deltaTime * speed * speedPercent, Space.Self);
            }

			yield return null;

		}
	}

	public void TakeDamage(int dmg)
    {
		health -= dmg;
		if(health <= 0)
        {
			Die();
        }
    }

	void Die()
    {
		GameObject _deathEffect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(_deathEffect, 1f);
		Destroy(gameObject);
    }
	void EndPath()
    {
		enemy.EndPath();
		Destroy(gameObject);
	}

	public void OnDrawGizmos()
	{
		if (path != null)
		{
			path.DrawWithGizmos();
		}
	}
}
