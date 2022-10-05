using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ShopWheelController : MonoBehaviour
{
    public Transform shopWheel;
    public bool wantShopWheel;


    public void ToggleShop(bool _wantShopWheel)
    {

        print("toggled shop");

        if (wantShopWheel == true)
            shopWheel.gameObject.SetActive(true);
        else
            shopWheel.gameObject.SetActive(false);
    }
}
