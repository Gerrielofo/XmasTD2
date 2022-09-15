using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.Users;

public class GamePadCursor : MonoBehaviour
{
    [SerializeField]
    private VirtualMouseInput virtualMouseInput;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform canvasRectTransform;
    [SerializeField]
    private float padding = 15f;
    [SerializeField]
    private bool previousMouseState;
    [SerializeField]
    private Mouse virtualMouse;
    private Mouse currentMouse;
    private Camera mainCamera;

    public ScriptablePlayerInfo playerInfo;
    public int playerID;

    private string previousControlScheme = "";
    private const string gamepadScheme = "Gamepad";
    private const string mouseScheme = "Keyboard&Mouse";

    public void Start()
    {
        playerID = playerInfo.playernumber++;
    }
    private void OnEnable()
    {
        mainCamera = Camera.main;
        currentMouse = Mouse.current;

        if(virtualMouse == null) virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");

        else if (!virtualMouse.added) InputSystem.AddDevice(virtualMouse);
        

        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if(virtualMouseInput.cursorTransform != null)
        {
            Vector2 position = virtualMouseInput.cursorTransform.anchoredPosition;
            InputState.Change(virtualMouse.position, position);
        }

        InputSystem.onAfterUpdate += UpdateMotion;
        playerInput.onControlsChanged += OnControlsChanged;
        //Debug.Log("Subbed");
    }

    private void OnDisable()
    {
        playerInfo.playernumber = 0;
        if(virtualMouse != null && virtualMouse.added) InputSystem.RemoveDevice(virtualMouse);

        InputSystem.onAfterUpdate -= UpdateMotion;
        playerInput.onControlsChanged -= OnControlsChanged;
        //Debug.Log("Unsubbed");
    }
    private void UpdateMotion()
    {
        //Debug.Log(Gamepad.current);
        //Debug.Log("jdfkalfjlkadjfkl");
        if(virtualMouse == null || Gamepad.current == null) return;

        Vector2 deltaValue = Gamepad.current.leftStick.ReadValue();
        //Debug.Log("Gamepad leftstick value = " + Gamepad.current.leftStick.ReadValue());
        deltaValue *= virtualMouseInput.cursorSpeed * Time.deltaTime;
        Debug.Log("player: " + playerInfo.playernumber.ToString());

        Vector2 currentposition = virtualMouse.position.ReadValue();
        Vector2 newPosistion = currentposition + deltaValue;
        //Debug.Log(newPosistion);

        newPosistion.x = Mathf.Clamp(newPosistion.x, padding, Screen.width/2 - padding);
        newPosistion.y = Mathf.Clamp(newPosistion.y, padding, Screen.height - padding);


        InputState.Change(virtualMouse.position, newPosistion);
        InputState.Change(virtualMouse.delta, deltaValue);

        AnchorCursor(newPosistion);

    }

    private void AnchorCursor(Vector2 position)
    {
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, position, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCamera, out anchoredPosition);
        virtualMouseInput.cursorTransform.anchoredPosition = anchoredPosition;
    }

    public void mouserAbc (InputAction.CallbackContext context )
    {
        //Debug.Log(context.ReadValue<Vector2>());
    }

    private void OnControlsChanged(PlayerInput input)
    {
        if(playerInput.currentControlScheme == mouseScheme && previousControlScheme != "mouseScheme")
        {
            virtualMouseInput.cursorTransform.gameObject.SetActive(false);
            Cursor.visible = true;
            currentMouse.WarpCursorPosition(virtualMouse.position.ReadValue());
            previousControlScheme = mouseScheme;

        }
        else if(playerInput.currentControlScheme == gamepadScheme && previousControlScheme != "gamepadScheme")
        {
            virtualMouseInput.cursorTransform.gameObject.SetActive(true);
            Cursor.visible = false;
            InputState.Change(virtualMouse.position, currentMouse.position.ReadValue());
            AnchorCursor(currentMouse.position.ReadValue());
            previousControlScheme = gamepadScheme;

        }
    }
}
 