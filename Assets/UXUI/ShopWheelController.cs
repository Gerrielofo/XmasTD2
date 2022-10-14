using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ShopWheelController : MonoBehaviour
{
    public Transform shopWheel;
    public bool wantShopWheel;
    public GameObject playerCursor;
    public bool shopShown;
    public Camera camera;

    public void Start()
    {
        playerCursor = gameObject.GetComponentInChildren<PlayerController>().gameObject;
    }
    public void ToggleShop(bool _wantShopWheel)
    {

        print("toggled shop" + _wantShopWheel);

        if (wantShopWheel && shopShown == false)
        {
            
            Vector3 newPosistion = new Vector3(playerCursor.transform.position.x, shopWheel.transform.position.y, playerCursor.transform.position.z);
            shopWheel.transform.position = newPosistion;
            shopWheel.gameObject.SetActive(true);
            shopShown = true;

        }
        else if (!wantShopWheel && shopShown == true)
        {
            shopWheel.gameObject.SetActive(false);
            shopShown = false;
        }   
        wantShopWheel = _wantShopWheel;
    }
}
