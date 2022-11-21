using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void PlaySound(AudioClip audio)
    {
        barulhoSource.PlayOneShot(audio);
    }
    public void PlayAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

}
