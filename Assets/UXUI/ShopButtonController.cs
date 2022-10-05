using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButtonController : MonoBehaviour
{
    public string itemName;
    public TextMeshProUGUI itemText;

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
        itemText.text = itemName;
    }

    public void HoverEnter()
    {
        itemText.text = itemName;
        buttonColor = Color.gray;
        buttonColor.a = 0.6f;
    }

    public void HoverExit()
    {
        itemText.text = "Select Tower";
        buttonColor = Color.black;
        buttonColor.a = 0.6f;
    }
}
