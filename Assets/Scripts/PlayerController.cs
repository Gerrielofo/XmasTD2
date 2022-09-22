using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float cursorSpeed = 5;
    private Vector2 movementInput;

    private void Update()
    {
        Debug.Log(movementInput);
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * cursorSpeed * Time.deltaTime);

        if(Keyboard.current.qKey.ReadValue() > 0)
        {

        }
    }

    public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

}
