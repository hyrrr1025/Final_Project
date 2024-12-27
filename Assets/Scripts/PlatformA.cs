using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformA : MonoBehaviour
{
    public GameObject platformA;    // ƽ̨ A
    public GameObject player;       // ����
    public GameObject NewobjectA;// ���� B ��Ԥ�Ƽ�
    public float delay = 2.0f;      // �ӳ�ʱ��

    private bool isCharacterOnPlatform = false;  // ��������Ƿ���ƽ̨��
    private bool isSpawning = false;             // ��ֹ��ε��� SpawnAndDropObjectB
    private GameObject spawnedNewobjectA = null;      // ��¼���ɵ�Ψһ Storm ʵ��

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ȷ����ײ�����������δ��ʼ���� Storm
        if (collision.gameObject == player && !isSpawning && spawnedNewobjectA == null)
        {
            isCharacterOnPlatform = true;
            isSpawning = true; // ���Ϊ��������
            Invoke(nameof(SpawnObjectA), delay);
        }
    }

    void SpawnObjectA()
    {
        if (isCharacterOnPlatform && spawnedNewobjectA == null)
        {
            // ��ƽ̨�Ϸ��������� B
            Vector2 spawnPosition = new Vector2(platformA.transform.position.x, platformA.transform.position.y + 5f);
            spawnedNewobjectA = Instantiate(NewobjectA, spawnPosition, Quaternion.identity);

            // �����������������
            spawnedNewobjectA.name = "NewobjectA";  // ������Ը�����Ҫ����

            // ������ B �������Ч������������
            Rigidbody2D rb = spawnedNewobjectA.AddComponent<Rigidbody2D>();

            // ������������
            rb.gravityScale = 1f; // ������������
            rb.mass = 3f;         // ��������
            //rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // ��ֹ��͸
        }
    }
}
