using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text noNoNoText;
    public AudioSource introMusic;
    public bool isMuted = false;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        noNoNoText.text = "No no no";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            introMusic.mute = !isMuted;
            isMuted = !isMuted;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            introMusic.volume -= 10f;
        }
        if (Input.GetKeyDown(KeyCode.Plus))
        {
            introMusic.volume += 10f;
        }
    }
}
