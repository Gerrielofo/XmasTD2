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
            if (hit.transform.tag == "Buildable")
            {
                BlueprintFollowMouse(hit.point + posOffset);
                Debug.Log(hit.point);
                if(hit.transform.tag == "Buildable"){
                    if (Input.GetButtonUp("Fire1"))
                    {
                        PlaceTower(hit.point);
                    }
                }
            }
        }
    }

    void BlueprintFollowMouse(Vector3 pos)
    {
        blueprintToUse.transform.position = pos;
    }

    void PlaceTower(Vector3 pos)
    {
        //Kill the blue print, instantiate the tower here.
        Destroy(blueprintToUse);
        Instantiate(towerToBuild, pos + posOffset, Quaternion.identity);
        BuildManager.instance.DeselectTurrets();
        canBuild = false;
    }
}
