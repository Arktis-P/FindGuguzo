using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem particleClick;

    [SerializeField] Transform MainCanvas;
    [SerializeField] GameObject objParticle;
    [SerializeField] GameObject prefabParticle;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (MainCanvas == null)
        {
            MainCanvas = GameObject.Find("Canvas").transform;
        }
        // ���콺 Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
            Vector3 mousePosition = Input.mousePosition;
            Vector3 spawnPosition = new Vector3(mousePosition.x, mousePosition.y, 0);

            // ĵ������ ���ο� ��ƼŬ ����
            CreateParticleAtPosition(spawnPosition);
        }
    }
    void CreateParticleAtPosition(Vector3 position)
    {
        // ��ƼŬ �ν��Ͻ� ����
        GameObject objParticle = Instantiate(prefabParticle, MainCanvas);
        ParticleSystem newParticle = objParticle.transform.GetChild(0).GetComponent<ParticleSystem>();

        // ��ƼŬ�� ��ġ�� ����
        objParticle.transform.position = position;

        // ��ƼŬ ���
        newParticle.Play();

        // ��ƼŬ�� ����Ǹ� �ڵ����� ����
        Destroy(newParticle.gameObject, newParticle.main.duration);
    }
}