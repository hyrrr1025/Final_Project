using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformB : MonoBehaviour
{
    public GameObject platformA;    // 平台 A
    public GameObject player;       // 人物
    public GameObject NewobjectB;// 物体 B 的预制件
    public float delay = 3.0f;      // 延迟时间

    private bool isCharacterOnPlatform = false;  // 检测人物是否在平台上
    private bool isSpawning = false;             // 防止多次调用 SpawnAndDropObjectB
    private GameObject spawnedNewobjectB = null;      // 记录生成的唯一 Storm 实例

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 确保碰撞对象是玩家且未开始生成 Storm
        if (collision.gameObject == player && !isSpawning && spawnedNewobjectB == null)
        {
            isCharacterOnPlatform = true;
            isSpawning = true; // 标记为正在生成
            Invoke(nameof(SpawnObjectB), delay);
        }
    }

    void SpawnObjectB()
    {
        if (isCharacterOnPlatform && spawnedNewobjectB == null)
        {
            // 在平台上方生成物体 B
            Vector2 spawnPosition = new Vector2(platformA.transform.position.x, platformA.transform.position.y + 5f);
            spawnedNewobjectB = Instantiate(NewobjectB, spawnPosition, Quaternion.identity);

            // 设置生成物体的名称
            spawnedNewobjectB.name = "NewobjectB";  // 这里可以根据需要命名

            // 给物体 B 添加物理效果，让它下落
            Rigidbody2D rb = spawnedNewobjectB.AddComponent<Rigidbody2D>();

            // 设置物理属性
            rb.gravityScale = 1f; // 设置重力缩放
            rb.mass = 3f;         // 设置质量
            //rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // 防止穿透
        }
    }
}
