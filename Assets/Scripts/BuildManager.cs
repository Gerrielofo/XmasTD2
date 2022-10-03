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
}
