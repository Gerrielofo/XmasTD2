using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float cursorSpeed = 5;
    private Vector2 movementInput;
    private float clickInput;
    private float shopInput;
    private Camera camera;
    public ShopWheelController shopWheelController;
    bool shopStatus;
    public PlayerInputManager inputManager;

    private void Awake()
    {
        inputManager = GameObject.Find("PlayerManager").GetComponent<PlayerInputManager>();
    }
    private void Update()
    {
        if(inputManager.playerCount == 2)
        {
            //Debug.Log(movementInput);
            //Debug.DrawRay(transform.position, transform.forward*1000, Color.red);
            transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * cursorSpeed * Time.deltaTime);
            if (clickInput > 0.5f)
            {
                RaycastHit hit;                
                if (Physics.Raycast(transform.position, transform.forward, out hit, 1000f))
                {
                    GameObject target = hit.transform.gameObject;
                    int _playerID = 0;
                    if (target.GetComponent<SendEnemies>())
                    {
                        int _enemyID = target.GetComponent<SendEnemies>().enemyID;

                        if (target.layer == 10)
                        {
                            _playerID = 1;
                        }
                        else if (target.layer == 11)
                        {
                            _playerID = 2;
                        }
                        int _ammount = target.GetComponent<SendEnemies>().ammount;
                        target.GetComponent<SendEnemies>().SendEnemy(_enemyID, _playerID, _ammount);
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

    public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnClick(InputAction.CallbackContext ctx) => clickInput = ctx.ReadValue<float>();
    public void OnShop(InputAction.CallbackContext ctx) => shopInput = ctx.ReadValue<float>();
}
