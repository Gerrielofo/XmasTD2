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

    private GameObject turretToBuild;
    private GameObject turretBlueprint;
    private int towerCost;

    public int tower1Cost = 100;
    public int tower2Cost = 200;
    public int tower3Cost = 250;
    public int tower4Cost = 400;

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
        GetComponent<TowerPlacement>().InitTowerPlacement(reindeerPrefab, reindeerBlueprintPrefab, tower1Cost);
        Debug.Log("Reindeer selected!");
    }

    public void SelectSnowman()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(snowmanPrefab, snowmanBlueprintPrefab, tower2Cost);
        Debug.Log("Snowman selected!");
    }

    public void SelectElves()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(elvePrefab, elveBlueprintPrefab, tower3Cost);
        Debug.Log("Elve selected!");
    }

    public void SelectYeti()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(yetiPrefab, yetiBlueprintPrefab, tower4Cost);
        Debug.Log("Yeti selected!");
    }
    public void SelectGhost()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(ghostPrefab, ghostBlueprintPrefab, tower1Cost);
        Debug.Log("Ghost selected!");
    }
    public void SelectWitch()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(witchPrefab, witchBlueprintPrefab, tower2Cost);
        Debug.Log("Witch selected!");
    }
    public void SelectSkeleton()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(skeletonPrefab, skeletonBlueprintPrefab, tower3Cost);
        Debug.Log("Skeleton selected!");
    }
    public void SelectGrimReaper()
    {
        GetComponent<TowerPlacement>().InitTowerPlacement(grimReaperPrefab, grimReaperBlueprintPrefab.gameObject, tower4Cost);
        Debug.Log("Grim Reaper selected!");
    }
}
