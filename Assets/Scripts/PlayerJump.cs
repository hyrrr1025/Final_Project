using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public GameObject platformA;       // ƽ̨ A �� GameObject
    public GameObject targetPosition;  // Ŀ��λ�õ� GameObject
    public float stayTime = 2f;        // ͣ��ʱ�� (��)
    public float moveSpeed = 5f;       // ����ƶ��ٶ�

    private bool isOnPlatformA = false; // ����Ƿ���ƽ̨ A ��
    private float timer = 0f;           // ��ʱ��
    private bool isMoving = false;      // ����Ƿ�ʼ�ƶ�
    private Vector2 moveDirection;      // ����ƶ�����

    private Rigidbody2D rb;             // 2D ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ��ȡ Rigidbody2D ���
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