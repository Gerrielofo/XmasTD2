using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPlacement : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Turret" || hit.transform.tag == "Track")
                {
                    Debug.Log("Can't place here!");
                }
                else
                {
                    GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
                    Instantiate(turretToBuild, hit.point, Quaternion.identity);
                }
            }

        }
    }
}
