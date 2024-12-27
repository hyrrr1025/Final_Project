using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFal : MonoBehaviour
{
    public GameObject player;
    public GameObject platformA;
    public GameObject platformB;
    public float delay = 0.1f;

    private bool isCharacterOnPlatform = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            isCharacterOnPlatform = true;
            Invoke(nameof(DropPlatformB), delay);
        }
    }

    void DropPlatformB()
    {
        if (isCharacterOnPlatform)
        {
            Rigidbody2D platformRb = platformB.AddComponent<Rigidbody2D>();
            platformRb.gravityScale = 1f;  // 设置平台的重力
            platformRb.mass = 10f;         // 设置平台的质量
        }
    }
}
