using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public float cursorSpeed = 5;
    private Vector2 movementInput;
    private float clickInput;
    private float shopInput;
    public Camera camera;
    public ShopWheelController shopWheelController;
    bool shopStatus;
    bool clicked;
    int playerID;
    public PlayerInputManager inputManager;


    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Vector3 worldPos;

    private void Awake()
    {
        inputManager = GameObject.Find("PlayerManager").GetComponent<PlayerInputManager>();
        transform.localPosition = new Vector3(0, 0, -55);
        
    }


    private void Update()
    {

        if (inputManager.playerCount == 2)
        {

            float cursorX = movementInput.x;
            float cursorY = movementInput.y;

            Vector3 pos = transform.localPosition;

            pos.x = Mathf.Clamp(pos.x, -940, 940);
            pos.y = Mathf.Clamp(pos.y, -1065, 1065);
            transform.localPosition = pos;

            transform.Translate(new Vector3(cursorX, cursorY, 0) * cursorSpeed * Time.deltaTime);

        }
    }
    public void OnButtonClicked(GameObject target, int _playerID)
    {
        if (clicked)
        {

            if (target.GetComponent<SendEnemies>())
            {
                int _enemyID = target.GetComponent<SendEnemies>().enemyID;


                int _ammount = target.GetComponent<SendEnemies>().ammount;
                int _cost = target.GetComponent<SendEnemies>().cost;
                target.GetComponent<SendEnemies>().SendEnemy(_enemyID, _playerID, _ammount, _cost);
            }
            else if (target.GetComponent<TowerID>())
            {
                int _towerID = target.GetComponent<TowerID>().towerID;
                int _towerCost = target.GetComponent<TowerID>().cost;
                if (target.layer == 10)
                {
                    _playerID = 1;
                }
                else if (target.layer == 11)
                {
                    _playerID = 2;
                }
                Debug.Log("PlayerID = " + _playerID);
                Debug.Log("TowerID = " + _towerID);
                Debug.Log("Towercost = " + _towerCost);
                target.GetComponent<TowerID>().ChangeTower(_towerID, _towerCost, _playerID);
            }
            else
            {
                Debug.Log("Nothing Found");
            }
        }
    }

    public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnClick(InputAction.CallbackContext ctx)
    {
        clickInput = ctx.ReadValue<float>();
        if (clickInput > 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000f))
            {
                clicked = true;
                GameObject target = hit.transform.gameObject;
                if (target.layer == 10)
                {
                    playerID = 1;
                }
                else if (target.layer == 11)
                {
                    playerID = 2;
                }
                OnButtonClicked(target, playerID);
            }
        }
    }
    public void OnShop(InputAction.CallbackContext ctx)
    {
        shopInput = ctx.ReadValue<float>();
        var shopWheel = gameObject.transform.GetComponentInParent<ShopWheelController>();

        if (shopInput < 0.5f && shopStatus == true)
        {
            shopWheel.ToggleShop(true);
            shopStatus = false;
        }
        else if (shopInput > 0.5f && shopStatus == false)
        {
            shopWheel.ToggleShop(false);
            shopStatus = true;
        }
    }
}