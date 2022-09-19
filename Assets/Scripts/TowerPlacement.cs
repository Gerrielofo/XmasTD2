using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    public Camera cam;
    private GameObject turret;
    public Vector3 posOffset;

    public GameObject towerSelectUI;

    void Start()
    {
        
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (BuildManager.instance.GetTurretToBuild() == null)
        {
            return;
        }
            
        if (Input.GetButtonDown("Fire1"))
        {

            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag is "Track" or "Enemy")
                {
                    Debug.Log("Can't place here!");
                }
                else
                {
                    GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
                    turret = (GameObject)Instantiate(turretToBuild, hit.point + posOffset, Quaternion.identity);
                    BuildManager.instance.DeselectTurrets();
                }
                if(hit.transform.tag is "Turret")
                {
                    if(towerSelectUI == isActiveAndEnabled)
                    towerSelectUI.SetActive(true);
                    else
                    {
                        towerSelectUI.SetActive(false);
                    }
                }
            }
        }
    }
}
