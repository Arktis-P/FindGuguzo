using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private Dictionary<string, AudioClip> soundDict;  // SFX�� BGM�� ������ Dictionary
    [SerializeField] private AudioSource sfxPlayer;                   // SFX ����� AudioSource
    [SerializeField] private AudioSource bgmPlayer;                   // BGM ����� AudioSource

    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] audioClips; // ����� Ŭ�� �迭

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGMWithFadeIn("normalBGM", 4f);
    }

    private void Init()
    {
        soundDict = new Dictionary<string, AudioClip>();
        bgmPlayer.loop = true; // BGM�� �⺻������ �ݺ� ���
        bgmPlayer.volume = 0.15f;

        // Dictionary �ʱ�ȭ
        foreach (var clip in audioClips)
        {
            soundDict[clip.name] = clip;
        }
    }

    // SFX ���
    public void PlaySFX(string soundName)
    {
        if (soundDict.TryGetValue(soundName, out var clip))
        {
            sfxPlayer.volume = 0.5f;
            if (soundName == "CardFlip")
            {
                sfxPlayer.volume = 0.8f;
            }
            sfxPlayer.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("SFX not found.");
        }
    }

    // BGM ���
    public void PlayBGM(string bgmName)
    {
        if (soundDict.TryGetValue(bgmName, out var clip))
        {
            if (bgmPlayer.clip != clip)
            {
                bgmPlayer.clip = clip;
                bgmPlayer.Play();
            }
        }
        else
        {
            Debug.LogWarning("BGM not found.");
        }
    }
    public void PlayBGMWithFadeIn(string bgmName, float fadeDuration)
    {
        if (soundDict.TryGetValue(bgmName, out var clip))
        {
            if (bgmPlayer.clip != clip)
            {
                bgmPlayer.clip = clip;
                bgmPlayer.volume = 0.05f; // ������ 0���� ����
                bgmPlayer.Play();
                StartCoroutine(FadeInBGM(fadeDuration));
            }
        }
        else
        {
            Debug.LogWarning("BGM not found.");
        }
    }
    // ���̵��� ȿ���� �����ϴ� �ڷ�ƾ
    private IEnumerator FadeInBGM(float duration)
    {
        float targetVolume = 0.15f; // ���̵����� ���� ���� (bgmPlayer �⺻ ����)
        float currentVolume = 0f;

        while (currentVolume < targetVolume)
        {
            currentVolume += Time.deltaTime / duration; // ���������� ���� ����
            bgmPlayer.volume = currentVolume;
            yield return null;
        }

        bgmPlayer.volume = targetVolume; // ���� �������� ����
    }
    public void AddPlayBGM(string bgmName, float fadeDuration)
    {
        if (soundDict.TryGetValue(bgmName, out var clip))
        {
            if (bgmPlayer.clip != clip)
            {
                bgmPlayer.clip = clip;
                bgmPlayer.volume = 0.05f; // ������ 0���� ����
                bgmPlayer.Play();
                StartCoroutine(FadeInBGM(fadeDuration));
            }
        }
        else
        {
            Debug.LogWarning("BGM not found.");
        }
    }
}