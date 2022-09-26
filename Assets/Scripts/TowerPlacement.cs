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
    
    bool canBuild = false;   
    public Camera cam;
    
    public Color blueprintMaterial;
    
    public GameObject buildEffect;

    void Update()
    {
        if (canBuild)
        {
            CheckIfCanBuild();
        }
    }

    public void InitTowerPlacement(GameObject newTowerToBuild, GameObject newBluePrintToUse)
    {
        towerToBuild = newTowerToBuild;
        SpawnBlueprint(newBluePrintToUse);
        canBuild = true;
    }
    void SpawnBlueprint(GameObject newBluePrintToUse)
    {
        blueprintToUse = Instantiate(newBluePrintToUse, transform.position, Quaternion.identity);
    }

    void CheckIfCanBuild()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        RaycastHit hit;
        Ray r = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out hit, Mathf.Infinity))
        {
            blueprintToUse.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = blueprintMaterial;

            BlueprintFollowMouse(hit.point + posOffset);
            if (hit.transform.tag == "Buildable")
            {
                blueprintMaterial = Color.white;
                blueprintMaterial.a = 0.5f;
                if (Input.GetButtonUp("Fire1"))
                {
                    PlaceTower(hit.point);
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
        Destroy(blueprintToUse);
        Instantiate(towerToBuild, pos + posOffset, Quaternion.identity);
        GameObject placeEffect = (GameObject)Instantiate(buildEffect, pos + posOffset, Quaternion.identity);
        Destroy(placeEffect, 1f);
        BuildManager.instance.DeselectTurrets();
        canBuild = false;
    }
}
