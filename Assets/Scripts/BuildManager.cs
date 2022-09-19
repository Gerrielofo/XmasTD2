using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    [Header("XMas Turrets")]
    public GameObject reindeerPrefab;
    public GameObject snowmanPrefab;
    public GameObject elvePrefab;
    public GameObject yetiPrefab;

    [Header("Halloween Turrets")]
    public GameObject ghostPrefab;
    public GameObject witchPrefab;
    public GameObject skeletonPrefab;
    public GameObject grimReaperPrefab;

    private void Start()
    {
        
    }

    private GameObject turretToBuild;
    

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void DeselectTurrets()
    {
        turretToBuild = null;
    }
    public void SelectReinDeer()
    {
        turretToBuild = reindeerPrefab;
        Debug.Log("Reindeer selected!");
    }

    public void SelectSnowman()
    {
        turretToBuild = snowmanPrefab;
        Debug.Log("Snowman selected!");
    }

    public void SelectElves()
    {
        turretToBuild = elvePrefab;
        Debug.Log("Elve selected!");
    }

    public void SelectYeti()
    {
        turretToBuild = yetiPrefab;
        Debug.Log("Yeti selected!");
    }
    public void SelectGhost()
    {
        turretToBuild = ghostPrefab;
        Debug.Log("Ghost selected!");
    }
    public void SelectWitch()
    {
        turretToBuild = witchPrefab;
        Debug.Log("Witch selected!");
    }
    public void SelectSkeleton()
    {
        turretToBuild = skeletonPrefab;
        Debug.Log("Skeleton selected!");
    }
    public void SelectGrimReaper()
    {
        turretToBuild = grimReaperPrefab;
        Debug.Log("Grim Reaper selected!");
    }
}
