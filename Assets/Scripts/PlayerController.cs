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
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * cursorSpeed * Time.deltaTime);
        Debug.Log("Moving!");
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
