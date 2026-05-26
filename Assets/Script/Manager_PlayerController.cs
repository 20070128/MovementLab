using UnityEngine;

public class Manager_PlayerController : MonoBehaviour
{
    //コンポーネント参照
    private Rigidbody rb;

    [Header("スクリプト参照")]
    [SerializeField] private InputManager inputManager;

    [Header("移動処理")]
    [SerializeField] private float moveSpeed = 5.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //移動処理
        rb.linearVelocity = new Vector3(inputManager.moveInput.x * moveSpeed, rb.linearVelocity.y, inputManager.moveInput.y * moveSpeed);
    }
}
