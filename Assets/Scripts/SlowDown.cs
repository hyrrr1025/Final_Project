using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public float targetY = 76.0f;
    public float duration = 2.0f;
    private bool isCollided = false;
    private Vector3 originalPosition;
    private Vector3 targetPosition;

    void Start()
    {
        originalPosition = transform.position;
        targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
    }

    public IEnumerator DelayAndLower()
    {
        if (!isCollided)
        {
            isCollided = true;
            yield return new WaitForSeconds(2);
            float elapsedTime = 0.0f;
            while (elapsedTime < duration)
            {
                transform.position = Vector3.Slerp(originalPosition, targetPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
        }
    }
}
