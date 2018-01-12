using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScript : MonoBehaviour {
    public AudioSource restartSound;
    //Replay the game
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("GamePage");
        this.restartSound.Play();
    }
    //Go back to main menu
    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("Start");
    }
}
