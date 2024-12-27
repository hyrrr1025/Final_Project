using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformB : MonoBehaviour
{
    public GameObject platformA;    // ƽ̨ A
    public GameObject player;       // ����
    public GameObject NewobjectB;// ���� B ��Ԥ�Ƽ�
    public float delay = 3.0f;      // �ӳ�ʱ��

    private bool isCharacterOnPlatform = false;  // ��������Ƿ���ƽ̨��
    private bool isSpawning = false;             // ��ֹ��ε��� SpawnAndDropObjectB
    private GameObject spawnedNewobjectB = null;      // ��¼���ɵ�Ψһ Storm ʵ��

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ȷ����ײ�����������δ��ʼ���� Storm
        if (collision.gameObject == player && !isSpawning && spawnedNewobjectB == null)
        {
            isCharacterOnPlatform = true;
            isSpawning = true; // ���Ϊ��������
            Invoke(nameof(SpawnObjectB), delay);
        }
    }

    void SpawnObjectB()
    {
        if (isCharacterOnPlatform && spawnedNewobjectB == null)
        {
            // ��ƽ̨�Ϸ��������� B
            Vector2 spawnPosition = new Vector2(platformA.transform.position.x, platformA.transform.position.y + 5f);
            spawnedNewobjectB = Instantiate(NewobjectB, spawnPosition, Quaternion.identity);

            // �����������������
            spawnedNewobjectB.name = "NewobjectB";  // ������Ը�����Ҫ����

            // ������ B �������Ч������������
            Rigidbody2D rb = spawnedNewobjectB.AddComponent<Rigidbody2D>();

            // ������������
            rb.gravityScale = 1f; // ������������
            rb.mass = 3f;         // ��������
            //rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // ��ֹ��͸
        }
    }
}
