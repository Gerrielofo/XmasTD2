using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ShopWheelController : MonoBehaviour
{
    public GameObject shopWheel;
    public bool wantShopWheel;
    public Image selectedItem;
    public Sprite noImage;
    public static int shopID;
    
    void Update()
    {
        if (Keyboard.current.tabKey.ReadValue() == 1)
        {
            wantShopWheel = true;

        }
        else
        {
            wantShopWheel = false;
        }

        if (wantShopWheel == true)
            shopWheel.SetActive(true);
        else
            shopWheel.SetActive(false);

        switch (shopID)
        {
            case 0:
                selectedItem.sprite = noImage;
                break;
        }
    }
}
