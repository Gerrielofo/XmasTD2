using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButtonController : MonoBehaviour
{
    public int id;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected;
    public Sprite icon;

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (selected)
        {
            selectedItem.sprite = icon;
            itemText.text = itemName;
        }
    }

    public void Selected()
    {
        selected = true;
    }
    public void Deselected()
    {
        selected = false;
    }

    public void HoverEnter()
    {
        anim.SetBool("Hover", true);
        itemText.text = itemName;
    }

    public void HoverExit()
    {
        anim.SetBool("Hover", false);
        itemText.text = "Select Tower";
    }
}
