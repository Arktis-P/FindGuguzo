using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene_Cloud : MonoBehaviour
{
    float minSpeed = 1f;
    float maxSpeed = 2.5f;
    float nowSpeed = 0;

    void Start()
    {
        // ������ ������ �ӵ� �����ϱ�
        nowSpeed = Random.Range(minSpeed, maxSpeed);
    }


    void Update()
    {
        // �ӵ� ������ ���� �������� �̵���Ű��
        transform.Translate(Vector3.left * nowSpeed * Time.deltaTime);

        // ���� ������ �ٴٸ��� ��Ʈ���� �ϱ� 
        if(transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
    }
}