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

    private bool previousMouseState;
    [SerializeField]
    private Mouse virtualMouse;
    private Camera mainCamera;

    private void OnEnable()
    {
        mainCamera = Camera.main;

        if(virtualMouse == null)
        {
            virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");

        }
        else if (!virtualMouse.added)
        {
            InputSystem.AddDevice(virtualMouse);
        }

        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if(cursorTransform != null)
        {
            Vector2 position = cursorTransform.anchoredPosition;
            InputState.Change(virtualMouse.position, position);
        }

        InputSystem.onAfterUpdate += UpdateMotion;
        Debug.Log("Subbed");
    }

    private void OnDisable()
    {
        InputSystem.RemoveDevice(virtualMouse);
        InputSystem.onAfterUpdate -= UpdateMotion;
        Debug.Log("Unsubbed");
    }
    private void UpdateMotion()
    {
        //Debug.Log(Gamepad.current);
        //Debug.Log("jdfkalfjlkadjfkl");
        if(virtualMouse == null || Gamepad.current == null)
        { 
            return;
        }

        

        Vector2 deltaValue = Gamepad.current.leftStick.ReadValue();
        //Debug.Log("Gamepad leftstick value = " + Gamepad.current.leftStick.ReadValue());
        deltaValue *= cursorSpeed * Time.deltaTime;
        //Debug.Log(deltaValue);

        Vector2 currentposition = virtualMouse.position.ReadValue();
        Vector2 newPosistion = currentposition + deltaValue;
        //Debug.Log(newPosistion);

        newPosistion.x = Mathf.Clamp(newPosistion.x, 0, Screen.width);
        newPosistion.y = Mathf.Clamp(newPosistion.y, 0, Screen.height);


        InputState.Change(virtualMouse.position, newPosistion);
        InputState.Change(virtualMouse.delta, deltaValue);

        

        bool aButtonIsPressed = Gamepad.current.aButton.IsPressed();
        if (previousMouseState != aButtonIsPressed && Gamepad.current.aButton.IsPressed())
        {
            Debug.Log("A button pressed");
            virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, aButtonIsPressed);
            InputState.Change(virtualMouse, mouseState);
            previousMouseState = aButtonIsPressed;
        }
        
        bool lTriggerIsPressed =  Gamepad.current.leftTrigger.IsPressed();
        
        if(previousMouseState != lTriggerIsPressed && Gamepad.current.leftTrigger.IsPressed())
        {
            Debug.Log("Left Trigger pressed");

            previousMouseState = lTriggerIsPressed;
        }

        Debug.Log(previousMouseState);
        AnchorCursor(newPosistion);

    }

    private void AnchorCursor(Vector2 position)
    {
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, position, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCamera, out anchoredPosition);
        cursorTransform.anchoredPosition = anchoredPosition;
    }

    public void mouserAbc (InputAction.CallbackContext context )
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

}
 