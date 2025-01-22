using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    float grey = 63f / 255f;

    public int idx = 0;

    public SpriteRenderer frontImage;
    public SpriteRenderer backImage;

    public GameObject front;
    public GameObject back;

    // Update is called once per frame
    public void Setting(int number, int backNumber)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Gugu{idx}");
        backImage.sprite = Resources.Load<Sprite>($"Cat{backNumber}");
    }

    // ī�� ����
    public void OpenCard()
    {
        Debug.Log("card selected");
        // secondCard�� �Ҵ�� ������ �ִٸ� �۵����� �ʱ�
        if (GameManager.Instance.secondCard != null) return;
        
        // ī���� �ո� ���̱�
        front.SetActive(true);
        back.SetActive(false);
        
        // firstCard�� �Ҵ�� ������ ���ٸ�,
        if (GameManager.Instance.firstCard == null)
        {
            // firstCard�� ���� �Ҵ��ϱ�
            GameManager.Instance.firstCard = this;
        }

        // firstCard�� �Ҵ�� ������ �ִٸ�,
        else
        {
            // secondCard�� ���� �Ҵ��ϱ�
            GameManager.Instance.secondCard = this;
            // first - second�� ����(idx) ���ϱ�
            GameManager.Instance.MatchCards();
        }
    }

    // ī�� �ݱ�
    public void CloseCard()
    {
        Invoke("CloseCardRaw", 1.0f);
    }

    void CloseCardRaw()
    {
        front.SetActive(false);
        back.SetActive(true);
    }

    // ī�� greyscale ��ȯ�ϱ�
    public void GreyCard()
    {
        Invoke("GreyCardRaw", 1.0f);
    }

    void GreyCardRaw()
    {
        frontImage.color = new Color(grey, grey, grey, 1.0f);
    }
}
