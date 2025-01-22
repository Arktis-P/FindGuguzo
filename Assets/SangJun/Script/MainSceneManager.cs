using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Transform MainCanvas;

    void Start()
    {
        GameManager.Instance.timeTxt = timeText;
        GameManager.Instance.MainCanvas = MainCanvas;
    }
}