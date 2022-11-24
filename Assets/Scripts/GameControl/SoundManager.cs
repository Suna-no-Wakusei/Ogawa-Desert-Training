using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager Null");
            }
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    [SerializeField] AudioSource musicSource, audioSource, barulhoSource;
    [SerializeField] AudioMixer mixer;
    float effectDb = -30.32f;
    float audioDb = -4.94f;
    float musicDb = -10.35f;
    float lowDb = -80f;

    void Start()
    {
        if (PlayerPrefs.GetInt("SoundVolume", 1) == 0)
        {
            mixer.SetFloat("EffectVolume", lowDb);
            mixer.SetFloat("AudioVolume", lowDb);
        }
        else
        {
            mixer.SetFloat("EffectVolume", effectDb);
            mixer.SetFloat("AudioVolume", audioDb);
        }
        if (PlayerPrefs.GetInt("MusicVolume", 1) == 0)
        {
            mixer.SetFloat("MusicVolume", lowDb);
        }
        else
        {
            mixer.SetFloat("MusicVolume", musicDb);
        }
    }

    public void PlaySound(AudioClip audio)
    {
        barulhoSource.PlayOneShot(audio);
    }
    public void PlayAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

}
