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

    public void ChangeTower(int _towerID, int _towerCost, int _playerID)
    {
        Debug.Log("Changing Tower");
        BuildManager buildManager = BuildManager.instance;
        TowerPlacement towerPlacement = playerCursor.GetComponent<TowerPlacement>();
        ShopWheelController shopwheelController = GetComponentInParent<ShopWheelController>();
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
/*            Debug.Log(buildManager);
            Debug.Log(buildManager.towerPrefabsXmas);*/
            towerPrefab = buildManager.towerPrefabsXmas[_towerID];
            towerBlueprint = buildManager.towerBlueprintXmas[_towerID];
        }

        towerPlacement.InitTowerPlacement(towerPrefab, towerBlueprint, cost);
        shopwheelController.ToggleShop(false);
    }
}
