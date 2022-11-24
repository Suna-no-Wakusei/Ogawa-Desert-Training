using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeMusicSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixerMusic;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;
    Image chldImg;
    float musicDb = -10.35f;
    float lowDb = -80f;
    bool musicActive = true;

    void Awake()
    {
        chldImg = gameObject.transform.GetChild(0).GetComponent<Image>();
        if (PlayerPrefs.GetInt("MusicVolume", 1) == 0)
        {
            musicActive = false;
            chldImg.sprite = off;
        }
        else
        {
            chldImg.sprite = on;
        }
    }

    public void KillMusic()
    {
        if (musicActive)
        {
            mixerMusic.SetFloat("MusicVolume", lowDb);
            chldImg.sprite = off;
            musicActive = false;
            PlayerPrefs.SetInt("MusicVolume", 0);
        }
        else
        {
            mixerMusic.SetFloat("MusicVolume", musicDb);
            chldImg.sprite = on;
            musicActive = true;
            PlayerPrefs.SetInt("MusicVolume", 1);
        }
    }
}
