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
    public GameObject[] towerPrefabsXmas;
    public GameObject[] towerBlueprintXmas; 

    [Header("Halloween Turrets")]
    public GameObject[] towerPrefabsHalloween;
    public GameObject[] towerBlueprintHalloween;

    public int tower1Cost = 100;
    public int tower2Cost = 200;
    public int tower3Cost = 250;
    public int tower4Cost = 400;

    public void ChangeTower(int _towerID, int _towerCost, int _playerID)
    {
        if(_playerID == 1)
        {
            switch (_towerID)
            {
                case 0:
                    GetComponent<TowerPlacement>().InitTowerPlacement(towerPrefabsXmas[_towerID], towerBlueprintXmas[_towerID], _towerCost);
                    break;
                case 1:
                    GetComponent<TowerPlacement>().InitTowerPlacement(towerPrefabsXmas[_towerID], towerBlueprintXmas[_towerID], _towerCost);
                    break;
                case 2:
                    GetComponent<TowerPlacement>().InitTowerPlacement(towerPrefabsXmas[_towerID], towerBlueprintXmas[_towerID], _towerCost);
                    break;
                case 3:
                    GetComponent<TowerPlacement>().InitTowerPlacement(towerPrefabsXmas[_towerID], towerBlueprintXmas[_towerID], _towerCost);
                    break;


            }
        }
        else if (_playerID == 2)
        {
            switch (_towerID)
            {
                case 0:
                    GetComponent<TowerPlacement>().InitTowerPlacement(towerPrefabsHalloween[_towerID], towerBlueprintHalloween[_towerID], _towerCost);
                    break;
                case 1:
                    GetComponent<TowerPlacement>().InitTowerPlacement(towerPrefabsHalloween[_towerID], towerBlueprintHalloween[_towerID], _towerCost);
                    break;
                case 2:
                    GetComponent<TowerPlacement>().InitTowerPlacement(towerPrefabsHalloween[_towerID], towerBlueprintHalloween[_towerID], _towerCost);
                    break;
                case 3:
                    GetComponent<TowerPlacement>().InitTowerPlacement(towerPrefabsHalloween[_towerID], towerBlueprintHalloween[_towerID], _towerCost);
                    break;


            }
        }

    }
}
