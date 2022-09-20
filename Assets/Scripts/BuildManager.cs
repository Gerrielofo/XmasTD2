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
    public GameObject reindeerBlueprintPrefab;
    public GameObject snowmanPrefab;
    public GameObject snowmanBlueprintPrefab;
    public GameObject elvePrefab;
    public GameObject elveBlueprintPrefab;
    public GameObject yetiPrefab;
    public GameObject yetiBlueprintPrefab;

    [Header("Halloween Turrets")]
    public GameObject ghostPrefab;
    public GameObject ghostBlueprintPrefab;
    public GameObject witchPrefab;
    public GameObject witchBlueprintPrefab;
    public GameObject skeletonPrefab;
    public GameObject skeletonBlueprintPrefab;
    public GameObject grimReaperPrefab;
    public GameObject grimReaperBlueprintPrefab;

    private void Start()
    {
        
    }

    private GameObject turretToBuild;
    private GameObject turretBlueprint;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public GameObject GetTurretBlueprint()
    {
        return turretBlueprint;
    }
    public void DeselectTurrets()
    {
        turretToBuild = null;
        turretBlueprint = null;
    }

    public void SelectReinDeer()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(reindeerPrefab, reindeerBlueprintPrefab);
        //turretToBuild = reindeerPrefab;
        //turretBlueprint = reindeerBlueprintPrefab;
        Debug.Log("Reindeer selected!");
    }

    public void SelectSnowman()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(snowmanPrefab, snowmanBlueprintPrefab);
        //turretToBuild = snowmanPrefab;
        //turretBlueprint = snowmanBlueprintPrefab;
        Debug.Log("Snowman selected!");
    }

    public void SelectElves()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(elvePrefab, elveBlueprintPrefab);
        //turretToBuild = elvePrefab;
        //turretBlueprint = elveBlueprintPrefab;
        Debug.Log("Elve selected!");
    }

    public void SelectYeti()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(yetiPrefab, yetiBlueprintPrefab);
        //turretToBuild = yetiPrefab;
        //turretBlueprint = yetiBlueprintPrefab;
        Debug.Log("Yeti selected!");
    }
    public void SelectGhost()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(ghostPrefab, ghostBlueprintPrefab);
        //turretToBuild = ghostPrefab;
        //turretBlueprint = ghostBlueprintPrefab;
        Debug.Log("Ghost selected!");
    }
    public void SelectWitch()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(witchPrefab, witchBlueprintPrefab);
        //turretToBuild = witchPrefab;
        //turretBlueprint = witchBlueprintPrefab;
        Debug.Log("Witch selected!");
    }
    public void SelectSkeleton()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(skeletonPrefab, skeletonBlueprintPrefab);
        //turretToBuild = skeletonPrefab;
        //turretBlueprint = skeletonBlueprintPrefab;
        Debug.Log("Skeleton selected!");
    }
    public void SelectGrimReaper()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(grimReaperPrefab, grimReaperBlueprintPrefab);
        //turretToBuild = grimReaperPrefab;
        //turretBlueprint = grimReaperBlueprintPrefab;
        Debug.Log("Grim Reaper selected!");
    }
}
