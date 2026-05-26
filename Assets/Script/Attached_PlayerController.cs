using UnityEngine;
using UnityEngine.InputSystem;

//PlayerInputコンポーネントをアタッチした場合の移動処理
public class Attached_PlayerController : MonoBehaviour
{
    //コンポーネント参照
    private Rigidbody rb;

    //移動処理
    private Vector2 moveInput;
    [Header("移動処理")]
    [SerializeField] private float moveSpeed = 5.0f;

    //Moveの移動処理
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().normalized;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //x座標とz座標での移動
        //速度ベクトルの書き換えで移動
        rb.linearVelocity = new Vector3(moveInput.x * moveSpeed, rb.linearVelocity.y, moveInput.y * moveSpeed);
    }
}
