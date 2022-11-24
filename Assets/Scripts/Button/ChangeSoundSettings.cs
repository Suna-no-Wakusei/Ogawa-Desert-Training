using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeSoundSettings : MonoBehaviour
{

    [SerializeField] AudioMixer mixer;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;
    Image chldImg;
    float effectDb = -30.32f;
    float audioDb = -4.94f;
    float lowDb = -80f;
    bool soundActive = true;

    void Awake()
    {
        chldImg = gameObject.transform.GetChild(0).GetComponent<Image>();
        if (PlayerPrefs.GetInt("SoundVolume", 1) == 0)
        {
            soundActive = false;
            chldImg.sprite = off;
        }
        else
        {
            chldImg.sprite = on;
        }
    }

    public void KillSound()
    {
        if (soundActive)
        {
            mixer.SetFloat("EffectVolume", lowDb);
            mixer.SetFloat("AudioVolume", lowDb);
            chldImg.sprite = off;
            soundActive = false;
            PlayerPrefs.SetInt("SoundVolume", 0);
        }
        else
        {
            mixer.SetFloat("EffectVolume", effectDb);
            mixer.SetFloat("AudioVolume", audioDb);
            chldImg.sprite = on;
            soundActive = true;
            PlayerPrefs.SetInt("SoundVolume", 1);
        }
    }

}
