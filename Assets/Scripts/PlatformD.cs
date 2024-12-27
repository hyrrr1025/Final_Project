using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformD : MonoBehaviour
{
    public GameObject platformA;    // ƽ̨ A
    public GameObject player;       // ����
    public GameObject NewobjectD;// ���� B ��Ԥ�Ƽ�
    public float delay = 5.0f;      // �ӳ�ʱ��

    private bool isCharacterOnPlatform = false;  // ��������Ƿ���ƽ̨��
    private bool isSpawning = false;             // ��ֹ��ε��� SpawnAndDropObjectB
    private GameObject spawnedNewobjectD = null;      // ��¼���ɵ�Ψһ Storm ʵ��

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ȷ����ײ�����������δ��ʼ���� Storm
        if (collision.gameObject == player && !isSpawning && spawnedNewobjectD == null)
        {
            isCharacterOnPlatform = true;
            isSpawning = true; // ���Ϊ��������
            Invoke(nameof(SpawnAndDropObjectD), delay);
        }
    }

    void SpawnAndDropObjectD()
    {
        if (isCharacterOnPlatform && spawnedNewobjectD == null)
        {
            // ��ƽ̨�Ϸ��������� B
            Vector2 spawnPosition = new Vector2(platformA.transform.position.x, platformA.transform.position.y + 5f);
            spawnedNewobjectD = Instantiate(NewobjectD, spawnPosition, Quaternion.identity);

            // �����������������
            spawnedNewobjectD.name = "NewobjectD";  // ������Ը�����Ҫ����

            // ������ B �������Ч������������
            Rigidbody2D rb = spawnedNewobjectD.AddComponent<Rigidbody2D>();

            // ������������
            rb.gravityScale = 1f; // ������������
            rb.mass = 3f;         // ��������
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // ��ֹ��͸

            if (platformA.GetComponent<Rigidbody2D>() == null)
            {
                Rigidbody2D platformRb = platformA.AddComponent<Rigidbody2D>();
                platformRb.gravityScale = 1f;  // ����ƽ̨������
                platformRb.mass = 10f;         // ����ƽ̨������
                platformRb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // ��ֹ��͸
            }
        }
    }
}
