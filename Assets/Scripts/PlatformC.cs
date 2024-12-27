using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformC : MonoBehaviour
{
    public GameObject platformA;    // ƽ̨ A
    public GameObject player;       // ����
    public GameObject NewobjectC;// ���� B ��Ԥ�Ƽ�
    public float delay = 4.0f;      // �ӳ�ʱ��

    private bool isCharacterOnPlatform = false;  // ��������Ƿ���ƽ̨��
    private bool isSpawning = false;             // ��ֹ��ε��� SpawnAndDropObjectB
    private GameObject spawnedNewobjectC = null;      // ��¼���ɵ�Ψһ Storm ʵ��

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ȷ����ײ�����������δ��ʼ���� Storm
        if (collision.gameObject == player && !isSpawning && spawnedNewobjectC == null)
        {
            isCharacterOnPlatform = true;
            isSpawning = true; // ���Ϊ��������
            Invoke(nameof(SpawnObjectC), delay);
        }
    }

    void SpawnObjectC()
    {
        if (isCharacterOnPlatform && spawnedNewobjectC == null)
        {
            // ��ƽ̨�Ϸ��������� B
            Vector2 spawnPosition = new Vector2(platformA.transform.position.x, platformA.transform.position.y + 5f);
            spawnedNewobjectC = Instantiate(NewobjectC, spawnPosition, Quaternion.identity);

            // �����������������
            spawnedNewobjectC.name = "NewobjectC";  // ������Ը�����Ҫ����

            // ������ B �������Ч������������
            Rigidbody2D rb = spawnedNewobjectC.AddComponent<Rigidbody2D>();

            // ������������
            rb.gravityScale = 1f; // ������������
            rb.mass = 3f;         // ��������
            //rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // ��ֹ��͸
        }
    }
}
