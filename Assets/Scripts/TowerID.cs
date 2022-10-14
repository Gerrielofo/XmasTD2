using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerID : MonoBehaviour
{
    public int towerID;
    public int cost;
    public GameObject towerPrefab;
    public GameObject towerBlueprint;
    public GameObject playerCursor;

    public BuildManager buildManager;

    private void Start()
    {
        buildManager = GameObject.Find("BuildManager").GetComponent<BuildManager>();
    }
    public void ChangeTower(int _towerID, int _towerCost, int _playerID)
    {
        Debug.Log("Changing Tower");
        
        TowerPlacement towerPlacement = playerCursor.GetComponent<TowerPlacement>();
        towerPlacement.playerCursor = playerCursor;
        if (_playerID == 1)
        {
            Debug.Log("changing for player 1");
            switch (_towerID)
            {
                case 0:
                    towerPrefab = buildManager.towerPrefabsHalloween[_towerID];
                    towerBlueprint = buildManager.towerBlueprintHalloween[_towerID];
                    Debug.Log("Case set");
                    break;
                case 1:
                    towerPrefab = buildManager.towerPrefabsHalloween[_towerID];
                    towerBlueprint = buildManager.towerBlueprintHalloween[_towerID];
                    break;
                case 2:
                    towerPrefab = buildManager.towerPrefabsHalloween[_towerID];
                    towerBlueprint = buildManager.towerBlueprintHalloween[_towerID];
                    break;
                case 3:
                    towerPrefab = buildManager.towerPrefabsHalloween[_towerID];
                    towerBlueprint = buildManager.towerBlueprintHalloween[_towerID];
                    break;


            }
        }
        else if (_playerID == 2)
        {
            Debug.Log("changing for player 2");
            switch (_towerID)
            {
                case 0:
                    towerPrefab = buildManager.towerPrefabsXmas[_towerID];
                    towerBlueprint = buildManager.towerBlueprintXmas[_towerID];
                    Debug.Log("Case set");
                    break;
                case 1:
                    towerPrefab = buildManager.towerPrefabsXmas[_towerID];
                    towerBlueprint = buildManager.towerBlueprintXmas[_towerID];
                    break;
                case 2:
                    towerPrefab = buildManager.towerPrefabsXmas[_towerID];
                    towerBlueprint = buildManager.towerBlueprintXmas[_towerID];
                    break;
                case 3:
                    towerPrefab = buildManager.towerPrefabsXmas[_towerID];
                    towerBlueprint = buildManager.towerBlueprintXmas[_towerID];
                    break;


            }
        }

        Debug.Log("Tower prefab = " + towerPrefab);
        Debug.Log("Tower blueprint = " + towerBlueprint);
        towerPlacement.InitTowerPlacement(towerPrefab, towerBlueprint, cost);
    }
}
