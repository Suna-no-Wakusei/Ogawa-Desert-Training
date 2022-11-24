using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] Animator ogAnimator;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioClip clip;
    bool isOn;

    public void Pause()
    {
        isOn = pauseMenu.activeSelf;
        SoundManager.Instance.PlaySound(clip);
        if (GameManager.Instance.IsOnRun)
        {
            if (isOn)
            {
                ogAnimator.SetBool("Moving", true);
                pauseMenu.SetActive(false);
                GameManager.Instance.IsOkToMove = true;
                GameManager.Instance.IsOkToSpawn = true;
                isOn = false;
            }
            else
            {
                ogAnimator.SetBool("Moving", false);
                Debug.Log("penis");
                pauseMenu.SetActive(true);
                GameManager.Instance.IsOkToMove = false;
                GameManager.Instance.IsOkToSpawn = false;
                isOn = true;
            }
        }
        else
        {
            if (isOn)
            {
                pauseMenu.SetActive(false);
                isOn = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                isOn = true;
            }
        }
    }
}