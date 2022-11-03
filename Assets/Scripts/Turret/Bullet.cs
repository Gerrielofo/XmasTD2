using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [Header("Bullet stats")]
    public int damage = 40;
    public float speed = 60f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

    [Header("Slow Attack")]
    public bool doSlow = false;
    public float slowPct = .7f;
    public float slowTime = 2f;

    public string enemyTag;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        if(explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == enemyTag)
            {
                Damage(collider.transform);
            }
        }
        Destroy(gameObject);
    }
    void Damage(Transform enemy)
    {
        Unit u = enemy.GetComponent<Unit>();
        if(u != null)
        {
            if (doSlow)
            {
                SlowEnemy(enemy);
            }
            u.TakeDamage(damage);
        }
    }

    void SlowEnemy(Transform enemy)
    {
        Unit u = enemy.GetComponent<Unit>();
        u.Slow(slowPct, slowTime);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
