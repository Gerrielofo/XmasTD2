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
            case 1: //Buy Reindeer
                Debug.Log("Reindeer selected");
            break;
            case 2: //Buy Snowman
                Debug.Log("SnowMan selected");
                break;
            case 3: //Buy Elves
                Debug.Log("Elves selected");
                break;
            case 4: //Buy Yeti
                Debug.Log("Yeti selected");
                break;
            case 0:
                selectedItem.sprite = null;
                break;
        }
    }
}
