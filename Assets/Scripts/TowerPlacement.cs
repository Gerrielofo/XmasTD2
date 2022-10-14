using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    public Vector3 posOffset;

    private GameObject blueprintToUse;
    private GameObject towerToBuild;
    private int towerCost;

    bool canBuild = false;   
    public GameObject playerCursor;
    
    public Color blueprintMaterial;
    
    public GameObject buildEffect;

    void Update()
    {
        if (canBuild)
        {
            CheckIfCanBuild();
        }
    }

    public void InitTowerPlacement(GameObject newTowerToBuild, GameObject newBluePrintToUse, int newTowerCost)
    {
        towerCost = newTowerCost;
        towerToBuild = newTowerToBuild;
        SpawnBlueprint(newBluePrintToUse);
        canBuild = true;
    }
    void SpawnBlueprint(GameObject newBluePrintToUse)
    {
        Destroy(blueprintToUse);
        blueprintToUse = Instantiate(newBluePrintToUse, transform.position, Quaternion.identity);
    }

    void CheckIfCanBuild()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(playerCursor.transform.position, playerCursor.transform.forward, out hit, Mathf.Infinity))
        {
            if (blueprintToUse.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>())
            {
                blueprintToUse.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = blueprintMaterial;
            }
            else
            {
                if (blueprintToUse.transform.GetChild(0).GetComponent<MeshRenderer>())
                {
                    blueprintToUse.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = blueprintMaterial;
                }
            }
            BlueprintFollowMouse(hit.point + posOffset);
            if (hit.transform.tag == "Buildable")
            {
                blueprintMaterial = Color.white;
                blueprintMaterial.a = 0.5f;
                if (Input.GetButtonUp("Fire1"))
                {
                    if(PlayerStats.player1Money > towerCost)
                    {
                        blueprintMaterial = Color.white;
                        blueprintMaterial.a = 0.5f;
                        PlaceTower(hit.point);
                    }
                    else
                    {
                        blueprintMaterial = Color.red;
                        blueprintMaterial.a = 0.5f;
                        Debug.Log("Not Enough Money!");
                    }
                }                
            }
            else
            {
                blueprintMaterial = Color.red;
                blueprintMaterial.a = 0.5f;
                return;
            }
        }
    }

    void BlueprintFollowMouse(Vector3 pos)
    {
        blueprintToUse.transform.position = pos;
    }

    void PlaceTower(Vector3 pos)
    {
        PlayerStats.player1Money -= towerCost;
        PlayerStats.player2Money -= towerCost;
        Debug.Log(PlayerStats.player1Money + " money left.");
        Destroy(blueprintToUse);
        Instantiate(towerToBuild, pos + posOffset, Quaternion.identity);
        GameObject placeEffect = (GameObject)Instantiate(buildEffect, pos + posOffset, Quaternion.identity);
        Destroy(placeEffect, 1f);
        canBuild = false;
    }
}