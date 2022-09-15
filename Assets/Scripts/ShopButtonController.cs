using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButtonController : MonoBehaviour
{
    public int id;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected;
    public Sprite icon;

    public Color buttonColor;
    
    void Start()
    {
        buttonColor = this.GetComponent<Image>().color;
        
    }


    void Update()
    {
        this.GetComponent<Image>().color = buttonColor;
    }

    public void Selected()
    {
        selected = true;
        selectedItem.sprite = icon;
        itemText.text = itemName;
        ShopWheelController.shopID = id;
    }
    public void Deselected()
    {
        selected = false;
        selectedItem.sprite = null;
        ShopWheelController.shopID = 0;
    }

    public void HoverEnter()
    {
        itemText.text = itemName;
        buttonColor = Color.gray;
        buttonColor.a = 1f / 2;
    }

    public void HoverExit()
    {
        itemText.text = "Select Tower";
        buttonColor = Color.white;
        buttonColor.a = 1f / 2;
    }
}
