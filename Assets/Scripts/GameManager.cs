using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isHard = false;
    public bool isHardPossible = false;
    public Text timeTxt;
    float time = 30f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ���� �� �������� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ��� GameManager ����
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2"); 
    }

    public void Change_Level()
    {
        isHard = !isHard;
    }
}
