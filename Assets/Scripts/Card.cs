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
    public GameObject backBtn;
    public Animator anim;
    // Update is called once per frame
    public void Update()
    {
        if(GameManager.Instance.isFail == true)
        {
            backBtn.SetActive(false);
        }
    }
    public void Setting(int number, int backNumber)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Gugu{idx}");
        backImage.sprite = Resources.Load<Sprite>($"Cat{backNumber}");
    }

    // ī�� ����
    public void OpenCard()
    {
        SoundManager.instance.PlaySFX("CardFlip");
        // Debug.Log("card selected");
        // secondCard�� �Ҵ�� ������ �ִٸ� �۵����� �ʱ�
        if (GameManager.Instance.secondCard != null) 
        {
            return;
        }

        // ī���� �ո� ���̱�
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
        // disactive card button
        // and should re-activate card button on close method

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
        anim.SetBool("isOpen", false);
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
