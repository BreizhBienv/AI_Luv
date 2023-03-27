using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene(3);
    }

    public void Tuto()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAudio ()
    {
        AudioSource sound = GameObject.FindGameObjectWithTag("UI").GetComponent<AudioSource>();
        sound.Play();
    }
}
