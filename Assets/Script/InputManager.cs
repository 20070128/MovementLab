using UnityEngine;
using UnityEngine.InputSystem;

//InputSystem_Actionsを直接インスタンス化して入力を取得する
public class InputManager : MonoBehaviour
{
    //PlayerControllerから移動方向を参照
    private InputSystem_Actions_Manager inputActions;
    public Vector2 moveInput { private set; get; }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().normalized;
    }
    void Awake()
    {
        inputActions = new InputSystem_Actions_Manager();
    }
    void OnEnable()
    {
        //Moveアクションにイベント登録
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Enable();
    }

    //オブジェクトが破棄された時用
    //今はいらない
    void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Disable();
    }
}
