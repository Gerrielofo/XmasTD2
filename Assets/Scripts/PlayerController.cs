using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float cursorSpeed = 5;
    private Vector2 movementInput;
    private float clickInput;
    private float shopInput;
    int enemyID;
    private Camera camera;
    public ShopWheelController shopWheelController;
    bool shopStatus;
    public PlayerInputManager inputManager;
    Transform shopWheel;

    private void Awake()
    {
        inputManager = GameObject.Find("PlayerManager").GetComponent<PlayerInputManager>();
    }
    private void Update()
    {
        if(inputManager.playerCount == 2)
        {
            //Debug.Log(movementInput);

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
                        Debug.Log(_playerID);
                        Debug.Log(_towerID);
                        Debug.Log(_towerCost);
                        target.GetComponent<TowerID>().ChangeTower(_towerID, _towerCost, _playerID);
                    }
                }
            }
            Transform shopWheel = gameObject.transform.GetComponentInParent<ShopWheelController>().shopWheel;

            if (shopInput > 0.5f && shopStatus == true)
            {
                print("shop true");
                shopWheel.gameObject.SetActive(true);
                shopStatus = false;
            }
            else if (shopInput < 0.5f && shopStatus == false)
            {
                print("shop false");
                shopWheel.gameObject.SetActive(false);
                shopStatus = true;
            }
        }
    }

    public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnClick(InputAction.CallbackContext ctx) => clickInput = ctx.ReadValue<float>();
    public void OnShop(InputAction.CallbackContext ctx) => shopInput = ctx.ReadValue<float>();
}
