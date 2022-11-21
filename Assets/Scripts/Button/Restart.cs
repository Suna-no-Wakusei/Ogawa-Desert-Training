using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    public void RestartGame()
    {
        SoundManager.Instance.PlaySound(clip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
