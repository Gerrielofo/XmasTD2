using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerID : MonoBehaviour
{
    public int towerID;
    public int cost;
    public GameObject towerPrefab;
    public GameObject towerBlueprint;

    // Start is called before the first frame update
    public void ChangeTower(int _towerID, int _towerCost, int _playerID)
    {
        var buildManager = GetComponent<BuildManager>();
        var towerPlacement = GetComponent<TowerPlacement>();
        if (_playerID == 1)
        {
            switch (_towerID)
            {
                case 0:
                    towerPrefab = buildManager.towerPrefabsHalloween[_towerID];
                    towerBlueprint = buildManager.towerBlueprintHalloween[_towerID];
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
            switch (_towerID)
            {
                case 0:
                    towerPrefab = buildManager.towerPrefabsXmas[_towerID];
                    towerBlueprint = buildManager.towerBlueprintXmas[_towerID];
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

        towerPlacement.InitTowerPlacement(towerPrefab, towerBlueprint, cost);

    }
}
