using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public int leftCards = 0;

    public bool isHard = false;
    public bool isHardPossible = false;

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
        
    }

    public void Change_Level()
    {
        isHard = !isHard;
    }

    // firstCard�� secondCard ����(idx) ���ϱ�
    public void MatchCards()
    {
        // idx �����ϸ�,
        if (firstCard.idx == secondCard.idx)
        {
            // ī�� greyscale ��ȯ
            // leftCards ����
            leftCards -= 2;

            // leftCards == 0�� ��,
            if (leftCards <= 0)
            {
                // ��������
                Time.timeScale = 0.0f;
                // EndScene ��ȯ
                SceneManager.LoadScene("EndScene");
                // ������� Ŭ���� ��, �ϵ��� �ر�
                if (isHard == false && isHardPossible == false)
                {
                    // isHardPossible �� ��ȯ
                    isHardPossible = true;
                }
            }
        }

        // idx �������� ���� ��,
        else
        {
            // ī�� �ݱ�
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        // ���� �ʱ�ȭ
        firstCard = null;
        secondCard = null;
    }
}
