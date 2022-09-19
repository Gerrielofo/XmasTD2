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

    public GameObject snowmanPrefab;

    private void Start()
    {
        turretToBuild = snowmanPrefab;
    }

    private GameObject turretToBuild;
    

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
