using UnityEngine;
using System.Collections;

public class SlowDown : MonoBehaviour
{
    public float targetY = 76.0f;  // Ŀ��Y��λ��
    public float duration = 2.0f;  // ���͵�ʱ��
    public GameObject player;      // ��Ҷ���
    private Vector3 originalPosition;  // ԭʼλ��
    private Vector3 targetPosition;   // Ŀ��λ��
    public float delay = 2.0f;      // �ӳ�ʱ�䣬��ײ���ÿ�ʼ����

    void Start()
    {
        originalPosition = transform.position;  // ��ʼ��ԭʼλ��
        targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);  // ����Ŀ��λ��
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)  // ����Ƿ�����ҷ�����ײ
        {
            // �ӳٵ��ý��ͷ���
            Invoke(nameof(Lower), delay);
        }
    }

    void Lower()
    {
        // ����Э��������ƽ̨���½�
        StartCoroutine(LowerCoroutine());
    }

    // Э�̷���������ƽ̨���½�
    IEnumerator LowerCoroutine()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            // ʹ�� Lerp ��ֵ����ƽ�����ƶ�ƽ̨
            float newY = Mathf.Lerp(originalPosition.y, targetPosition.y, elapsedTime / duration);
            transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);  // ֻ�ı�Y��
            elapsedTime += Time.deltaTime;  // ���Ӿ�����ʱ��
            yield return null;  // �ȴ���һ֡
        }
        // ȷ������λ��ΪĿ��λ��
        transform.position = targetPosition;
    }
}
