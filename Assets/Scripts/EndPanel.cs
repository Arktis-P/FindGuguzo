using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    public GameObject HardPanel;
    public GameObject EazyPanel;
    public GameObject ImgPanel;

    void Start()
    {
        // �ϵ��带 Ŭ���� �Ͽ����� GameManager���� isHard�� �����ܼ� üũ
        bool isHardMode = GameManager.Instance.isHard;
        // �ϵ��带 Ŭ���� �� ���� HardPanel�� �����ְ� EazyPanel�� ����
        if (isHardMode)
        {
            HardPanel.SetActive(true);
            EazyPanel.SetActive(false);
        }
    }

    // �̹����� Ŭ������ �� �ݴ� ��ư
    public void CloseBtn()
    {
        ImgPanel.SetActive(false);
    }


}
