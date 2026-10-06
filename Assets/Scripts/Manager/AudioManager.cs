using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    public AudioClip sunlightMusic;   // default loop for the whole game
    public AudioClip chimesMusic;     // plays only in the scenes listed below
    public string[] chimesScenes;     // exact scene names, e.g. "Level3"

    [Header("SFX")]
    public AudioClip clickSFX;
    public AudioClip coinSFX;

    [Header("Volume")]
    [Range(0f, 1f)] public float musicVolume = 0.5f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    AudioSource musicSource;
    AudioSource sfxSource;

    void Awake()
    {
        // Singleton: if another AudioManager already exists, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.playOnAwake = false;
        musicSource.volume = musicVolume;

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.loop = false;
        sfxSource.playOnAwake = false;
        sfxSource.volume = sfxVolume;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        // Covers the very first scene, in case sceneLoaded fired before we subscribed
        if (Instance == this)
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
        HookAllButtons();
    }

    // ---------- MUSIC ----------
    void PlayMusicForScene(string sceneName)
    {
        bool useChimes = Array.IndexOf(chimesScenes, sceneName) >= 0;
        AudioClip wanted = useChimes ? chimesMusic : sunlightMusic;

        // Already playing the right track? Leave it alone (so restarting a level
        // doesn't restart the music from the beginning)
        if (musicSource.clip == wanted && musicSource.isPlaying) return;

        musicSource.Stop();
        musicSource.clip = wanted;
        musicSource.Play();
    }

    // ---------- SFX ----------
    public void PlayClick()
    {
        if (clickSFX) sfxSource.PlayOneShot(clickSFX, sfxVolume);
    }

    public void PlayCoin()
    {
        if (coinSFX) sfxSource.PlayOneShot(coinSFX, sfxVolume);
    }

    // ---------- AUTO-HOOK EVERY BUTTON ----------
    void HookAllButtons()
    {
        Button[] buttons = FindObjectsByType<Button>(
            FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (Button b in buttons)
        {
            b.onClick.RemoveListener(PlayClick); // avoids double-adding
            b.onClick.AddListener(PlayClick);
        }
    }
}