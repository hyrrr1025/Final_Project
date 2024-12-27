using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInteraction : MonoBehaviour
{
    public GameObject platformA;    // ƽ̨ A
    public GameObject player;       // ����
    public GameObject Newobject;        // ���� B ��Ԥ�Ƽ�
    public float delay = 2.0f;      // �ӳ�ʱ��

    private bool isCharacterOnPlatform = false;  // ��������Ƿ���ƽ̨��
    private bool isSpawning = false;             // ��ֹ��ε��� SpawnAndDropObjectB
    private GameObject spawnedNewobject = null;      // ��¼���ɵ�Ψһ Storm ʵ��

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ȷ����ײ�����������δ��ʼ���� Storm
        if (collision.gameObject == player && !isSpawning && spawnedNewobject == null)
        {
            isCharacterOnPlatform = true;
            isSpawning = true; // ���Ϊ��������
            Invoke(nameof(SpawnAndDropObjectB), delay);
        }
    }

    void SpawnAndDropObjectB()
    {
        // ȷ���������ƽ̨�ϣ���δ���� Storm
        if (isCharacterOnPlatform && spawnedNewobject == null)
        {
            // ��ƽ̨�Ϸ��������� B
            Vector2 spawnPosition = new Vector2(platformA.transform.position.x, platformA.transform.position.y + 5f);
            spawnedNewobject = Instantiate(Newobject, spawnPosition, Quaternion.identity);

            // �����������������
            spawnedNewobject.name = "Newobject";  // ������Ը�����Ҫ����

            // ������ B �������Ч������������
            Rigidbody2D rb = spawnedNewobject.AddComponent<Rigidbody2D>();

            // ������������
            rb.gravityScale = 1f; // ������������
            rb.mass = 5f;         // ��������
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