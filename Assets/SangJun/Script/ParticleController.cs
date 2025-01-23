using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public static ParticleController instance;

    [SerializeField] ParticleSystem particleClick;

    [SerializeField] Transform MainCanvas;
    [SerializeField] GameObject objParticle;
    [SerializeField] GameObject prefabParticle;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

            Vector3 spawnPosition = new Vector3(worldPosition.x, worldPosition.y, -1f);

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