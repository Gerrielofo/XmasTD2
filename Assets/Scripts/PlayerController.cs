using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float cursorSpeed = 5;
    private Vector2 movementInput;
    int enemyID;

    private void Update()
    {
        //Debug.Log(movementInput);
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * cursorSpeed * Time.deltaTime);
        if (Gamepad.current.aButton.isPressed)
        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000f))
            {
                Debug.Log(hit);
                var enemySend = hit.collider.GetComponent<SendEnemies>();
                if (gameObject.GetComponentInParent<Camera>().cullingMask == LayerMask.GetMask("Player1"))
                {
                    switch (hit.collider.GetComponent<SendEnemies>().enemyID)
                    {
                        case 0:
                            enemyID = enemySend.enemyID;
                            enemySend.SendEnemy(enemyID, 1);
                            break;
                        case 1:
                            enemyID = enemySend.enemyID;
                            enemySend.SendEnemy(enemyID, 1);
                            break;
                        case 2:
                            enemyID = enemySend.enemyID;
                            enemySend.SendEnemy(enemyID, 1);
                            break;
                        case 3:
                            enemyID = enemySend.enemyID;
                            enemySend.SendEnemy(enemyID, 1);
                            break;
                    }
                }
                if (gameObject.GetComponentInParent<Camera>().cullingMask == LayerMask.GetMask("Player2"))
                {
                    switch (enemySend.enemyID)
                    {
                        case 0:
                            enemyID = enemySend.enemyID;
                            enemySend.SendEnemy(enemyID, 2);
                            break;
                        case 1:
                            enemyID = enemySend.enemyID;
                            enemySend.SendEnemy(enemyID, 2);
                            break;
                        case 2:
                            enemyID = enemySend.enemyID;
                            enemySend.SendEnemy(enemyID, 2);
                            break;
                        case 3:
                            enemyID = enemySend.enemyID;
                            enemySend.SendEnemy(enemyID, 2);
                            break;
                    }
                }
            }
        }

    }

    public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
