using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;

    [SerializeField] StartSceneManager startSceneManager;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
            LoadData();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    void LoadData()
    {
        if (PlayerPrefs.HasKey("isHardPossible")) // Ű�� �����ϴ� ���
        {
            // int ���� bool�� ��ȯ
            GameManager.Instance.isHardPossible = PlayerPrefs.GetInt("isHardPossible") == 1;
        }

        /*if (PlayerPrefs.HasKey("BGMVolume")) // Ű�� �����ϴ� ���
        {
            SoundManager.instance.BGMVolume = PlayerPrefs.GetFloat("BGMVolume");
        }
        if (PlayerPrefs.HasKey("SFXVolume")) // Ű�� �����ϴ� ���
        {
            SoundManager.instance.SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        }
        startSceneManager.soundVisualInit();*/
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("isHardPossible", GameManager.Instance.isHardPossible ? 1 : 0); // bool ���� int�� ��ȯ
       // PlayerPrefs.SetFloat("BGMVolume", SoundManager.instance.BGMVolume);
       // PlayerPrefs.SetFloat("SFXVolume", SoundManager.instance.SFXVolume);
        PlayerPrefs.Save(); // ������� ����
        Debug.Log("����");
    }
}
