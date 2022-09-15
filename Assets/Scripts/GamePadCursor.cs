using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class GamePadCursor : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private RectTransform cursorTransform;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform canvasRectTransform;
    [SerializeField]
    private float cursorSpeed = 1000;
    [SerializeField]
    private float padding = 15f;
    [SerializeField]
    private Mouse virtualMouse;
    private Mouse currentMouse;
    private Camera mainCamera;

    private string previousControlScheme = "";
    private const string gamepadScheme = "Gamepad";
    private const string mouseScheme = "Keyboard&Mouse";

    private void OnEnable()
    {
        mainCamera = Camera.main;
        currentMouse = Mouse.current;

        if(virtualMouse == null) virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");

        else if (!virtualMouse.added) InputSystem.AddDevice(virtualMouse);
        

        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if(cursorTransform != null)
        {
            Vector2 position = cursorTransform.anchoredPosition;
            InputState.Change(virtualMouse.position, position);
        }

        InputSystem.onAfterUpdate += UpdateMotion;
        playerInput.onControlsChanged += OnControlsChanged;
        Debug.Log("Subbed");
    }

    private void OnDisable()
    {
        if(virtualMouse != null && virtualMouse.added) InputSystem.RemoveDevice(virtualMouse);

        InputSystem.onAfterUpdate -= UpdateMotion;
        playerInput.onControlsChanged -= OnControlsChanged;
        Debug.Log("Unsubbed");
    }
    private void UpdateMotion()
    {
        /*
        //Debug.Log(Gamepad.current);
        //Debug.Log("jdfkalfjlkadjfkl");
        if(virtualMouse == null || Gamepad.current == null) return;

        Vector2 deltaValue = Gamepad.current.leftStick.ReadValue();
        //Debug.Log("Gamepad leftstick value = " + Gamepad.current.leftStick.ReadValue());
        deltaValue *= cursorSpeed * Time.deltaTime;
        //Debug.Log(deltaValue);

        Vector2 currentposition = virtualMouse.position.ReadValue();
        Vector2 newPosistion = currentposition + deltaValue;
        //Debug.Log(newPosistion);

        newPosistion.x = Mathf.Clamp(newPosistion.x, padding, Screen.width - padding);
        newPosistion.y = Mathf.Clamp(newPosistion.y, padding, Screen.height - padding);


        InputState.Change(virtualMouse.position, newPosistion);
        InputState.Change(virtualMouse.delta, deltaValue);

        AnchorCursor(newPosistion);
        */
    }

    private void AnchorCursor(Vector2 position)
    {
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, position, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCamera, out anchoredPosition);
        cursorTransform.anchoredPosition = anchoredPosition;
    }

    public void mouserAbc (InputAction.CallbackContext context )
    {
        //Debug.Log(context);

        Vector2 deltaValue = context.ReadValue<Vector2>();
        //Debug.Log("Gamepad leftstick value = " + Gamepad.current.leftStick.ReadValue());
        Debug.Log(deltaValue);
    }

    private void OnControlsChanged(PlayerInput input)
    {
        if(playerInput.currentControlScheme == mouseScheme && previousControlScheme != mouseScheme)
        {
            cursorTransform.gameObject.SetActive(false);
            Cursor.visible = true;
            currentMouse.WarpCursorPosition(virtualMouse.position.ReadValue());
            previousControlScheme = mouseScheme;

        }
        else if(playerInput.currentControlScheme == gamepadScheme && previousControlScheme != gamepadScheme)
        {
            cursorTransform.gameObject.SetActive(true);
            Cursor.visible = false;
            InputState.Change(virtualMouse.position, currentMouse.position.ReadValue());
            AnchorCursor(currentMouse.position.ReadValue());
            previousControlScheme = gamepadScheme;

        }
    }

}
 