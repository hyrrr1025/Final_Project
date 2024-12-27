using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public GameObject platformA;       // 平台 A 的 GameObject
    public GameObject targetPosition;  // 目标位置的 GameObject
    public float stayTime = 2f;        // 停留时间 (秒)
    public float moveSpeed = 5f;       // 玩家移动速度

    private bool isOnPlatformA = false; // 玩家是否在平台 A 上
    private float timer = 0f;           // 计时器
    private bool isMoving = false;      // 玩家是否开始移动
    private Vector2 moveDirection;      // 玩家移动方向

    private Rigidbody2D rb;             // 2D 刚体

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 获取 Rigidbody2D 组件
    }

    void Update()
    {
        if (isOnPlatformA && !isMoving)
        {
            timer += Time.deltaTime;

            if (timer >= stayTime)
            {
                StartMovingToTarget();
            }
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.velocity = moveDirection * moveSpeed;
        }
    }

    private void StartMovingToTarget()
    {
        isMoving = true;

        Vector2 direction = (targetPosition.transform.position - transform.position).normalized;
        moveDirection = direction;

        Debug.Log($"Start moving to target. Direction: {direction}");

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == platformA)
        {
            isOnPlatformA = true;
            timer = 0f;
            Debug.Log("Player is on platform A");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == platformA)
        {
            isOnPlatformA = false;
            timer = 0f;
            Debug.Log("Player left platform A");
        }
    }
}