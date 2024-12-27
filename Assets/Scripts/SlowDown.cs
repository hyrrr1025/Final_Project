using UnityEngine;
using System.Collections;

public class SlowDown : MonoBehaviour
{
    public float targetY = 76.0f;  // 目标Y轴位置
    public float duration = 2.0f;  // 降低的时间
    public GameObject player;      // 玩家对象
    private Vector3 originalPosition;  // 原始位置
    private Vector3 targetPosition;   // 目标位置
    public float delay = 2.0f;      // 延迟时间，碰撞后多久开始降低

    void Start()
    {
        originalPosition = transform.position;  // 初始化原始位置
        targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);  // 设置目标位置
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)  // 检查是否与玩家发生碰撞
        {
            // 延迟调用降低方法
            Invoke(nameof(Lower), delay);
        }
    }

    void Lower()
    {
        // 启动协程来处理平台的下降
        StartCoroutine(LowerCoroutine());
    }

    // 协程方法，处理平台的下降
    IEnumerator LowerCoroutine()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            // 使用 Lerp 插值函数平滑地移动平台
            float newY = Mathf.Lerp(originalPosition.y, targetPosition.y, elapsedTime / duration);
            transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);  // 只改变Y轴
            elapsedTime += Time.deltaTime;  // 增加经过的时间
            yield return null;  // 等待下一帧
        }
        // 确保最终位置为目标位置
        transform.position = targetPosition;
    }
}
