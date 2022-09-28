using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float cursorSpeed = 5;
    private Vector2 movementInput;
    int enemyID;
    private Camera camera;

    private void Update()
    {
        //Debug.Log(movementInput);

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * cursorSpeed * Time.deltaTime);
        if (Gamepad.current.aButton.isPressed)
        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000f))
            {
                Debug.Log(hit.collider);
                
            }
        }

    }

    public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
