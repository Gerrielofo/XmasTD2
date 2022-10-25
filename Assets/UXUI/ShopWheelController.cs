using UnityEngine;

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
        if (wantShopWheel && !shopShown)
        {
            
            Vector3 newPosistion = new Vector3(playerCursor.transform.position.x, shopWheel.transform.position.y, playerCursor.transform.position.z);
            shopWheel.transform.position = newPosistion;
            shopWheel.gameObject.SetActive(true);
            shopShown = true;
            print("toggled shop" + _wantShopWheel);
        }
        else if (!wantShopWheel && shopShown)
        {
            shopWheel.gameObject.SetActive(false);
            shopShown = false;
            print("toggled shop" + _wantShopWheel);
        }   
        wantShopWheel = _wantShopWheel;
    }
}
