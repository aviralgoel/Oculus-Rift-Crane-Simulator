using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    [Header("Main Background SoundFX")]
    public AudioClip background;

    [Header("Main Menu Sounds")]
    public AudioClip toggle;
    public AudioClip click;

    [Header("Main Level Sounds")]
    public AudioClip craneEngine;

    AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
         audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClickSound()
    {
        audioSource.clip = click;
        audioSource.Play();
    }
    public void PlayToggleSound()
    {
        audioSource.clip = toggle;
        audioSource.Play();
    }
}
