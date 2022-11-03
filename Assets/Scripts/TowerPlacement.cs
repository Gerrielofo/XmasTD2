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

    float confirmPlace;
    float cancelPlace;

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
        GetComponentInParent<ShopWheelController>().ToggleShop(false);
    }
    void SpawnBlueprint(GameObject newBluePrintToUse)
    {
        Destroy(blueprintToUse);
        blueprintToUse = Instantiate(newBluePrintToUse, transform.position, Quaternion.identity);
    }

    void CheckIfCanBuild()
    {
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
                else print("No Mesh Renderer Found!");
            }
            BlueprintFollowMouse(hit.point + posOffset);
            if (hit.transform.tag == "Buildable")
            {
                blueprintMaterial = Color.white;
                blueprintMaterial.a = 0.6f;
                if (confirmPlace > 0.5f)
                {
                    if (playerCursor.layer == 10)
                    {
                        if (PlayerStats.player1Money > towerCost)
                        {
                            blueprintMaterial = Color.white;
                            blueprintMaterial.a = 0.6f;
                            PlaceTower(hit.point);
                            PlayerStats.player1Money -= towerCost;
                        }
                        else
                        {
                            blueprintMaterial = Color.red;
                            blueprintMaterial.a = 0.6f;
                            Debug.Log("Not Enough Money!");
                        }
                    }
                    else if (playerCursor.layer == 11)
                    {
                        if (PlayerStats.player2Money > towerCost)
                        {
                            blueprintMaterial = Color.white;
                            blueprintMaterial.a = 0.6f;
                            PlaceTower(hit.point);
                            PlayerStats.player2Money -= towerCost;
                        }
                        else
                        {
                            blueprintMaterial = Color.red;
                            blueprintMaterial.a = 0.6f;
                            Debug.Log("Not Enough Money!");
                        }
                    }


                }
            }
            else
            {
                blueprintMaterial = Color.red;
                blueprintMaterial.a = 0.6f;

                if (confirmPlace > 0.5f)
                {
                    blueprintMaterial = Color.red;
                    blueprintMaterial.a = 0.6f;
                    print("Can't build here!");
                }
            }
            if (cancelPlace > 0.5f)
            {
                Deselect();
            }
        }
    }

    void BlueprintFollowMouse(Vector3 pos)
    {
        blueprintToUse.transform.position = pos;
    }

    void Deselect()
    {
        Destroy(blueprintToUse);
        canBuild = false;
        towerToBuild = null;
    }
    void PlaceTower(Vector3 pos)
    {
        Destroy(blueprintToUse);
        Instantiate(towerToBuild, pos + posOffset, Quaternion.identity);
        GameObject placeEffect = (GameObject)Instantiate(buildEffect, pos + posOffset, Quaternion.identity);
        placeEffect.layer = playerCursor.layer;
        Destroy(placeEffect, 1f);
        canBuild = false;
    }

    public void onConfirmPlace(InputAction.CallbackContext ctx) => confirmPlace = ctx.ReadValue<float>();
    public void onCancelPlace(InputAction.CallbackContext ctx) => cancelPlace = ctx.ReadValue<float>();
}