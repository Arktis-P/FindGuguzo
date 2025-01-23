using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LatterBox : MonoBehaviour
{
    public static LatterBox instance;

    [SerializeField] Camera subCam;
    private ScreenOrientation lastOrientation;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Screen.orientation = ScreenOrientation.Portrait;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] private float targetWidth = 760f; // ���� �ػ��� ���ΰ�
    [SerializeField] private float targetHeight = 1280f; // ���� �ػ��� ���ΰ�

    private void Start()
    {    
        // ���� �� ȭ�� ������ �����մϴ�.
        lastOrientation = Screen.orientation;
    }
    void Update()
    {
        // ȭ�� ������ ����Ǿ��� ���� ���͹ڽ��� �ٽ� �����մϴ�.
        if (Screen.orientation != lastOrientation)
        {
            lastOrientation = Screen.orientation;
            SetLatterBox(); // ���͹ڽ� �ٽ� �׸���
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       // AdjustCameraSize();
        SetLatterBox();
    }
    private void AdjustCameraSize()
    {
        // ���� �ػ��� ����
        float targetAspect = targetWidth / targetHeight;

        // ���� ����� ȭ�� ����
        float screenAspect = (float)Screen.width / Screen.height;

        // ī�޶��� orthographicSize ����
        Camera camera = Camera.main;

        if (screenAspect < targetAspect) // ȭ�� ������ �� ����
        {
            float scaleFactor = targetAspect / screenAspect;
            camera.orthographicSize = (targetHeight / 200f) * scaleFactor;
        }
        else // ȭ�� ������ ���ų� �� ����
        {
            camera.orthographicSize = targetHeight / 200f;
        }
    }

    void SetLatterBox()
    {
        Camera camera = Camera.main;
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / (760f / 1280f); // (���� / ����)
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }
    void OnPostRender()
    {
        GL.PushMatrix();
        GL.LoadOrtho(); // ����ȭ�� ��ǥ��(0~1)�� ��ȯ
        GL.Begin(GL.QUADS);
        GL.Color(Color.black); // ���������� ����

        // ��� ���͹ڽ�
        GL.Vertex3(0, 1 - Camera.main.rect.yMax, 0);
        GL.Vertex3(1, 1 - Camera.main.rect.yMax, 0);
        GL.Vertex3(1, 1, 0);
        GL.Vertex3(0, 1, 0);

        // �ϴ� ���͹ڽ�
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(1, 0, 0);
        GL.Vertex3(1, Camera.main.rect.yMin, 0);
        GL.Vertex3(0, Camera.main.rect.yMin, 0);

        // ���� ���͹ڽ� (�ʿ��� ���)
        if (Camera.main.rect.xMin > 0)
        {
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(Camera.main.rect.xMin, 0, 0);
            GL.Vertex3(Camera.main.rect.xMin, 1, 0);
            GL.Vertex3(0, 1, 0);
        }

        // ���� ���͹ڽ� (�ʿ��� ���)
        if (Camera.main.rect.xMax < 1)
        {
            GL.Vertex3(Camera.main.rect.xMax, 0, 0);
            GL.Vertex3(1, 0, 0);
            GL.Vertex3(1, 1, 0);
            GL.Vertex3(Camera.main.rect.xMax, 1, 0);
        }

        GL.End();
        GL.PopMatrix();
    }
}
