using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {
    public AudioSource startSound;

    public void OnButtonClick()
    {
        //Debug.Log("Start button clicked!");
        SceneManager.LoadScene("GamePage");
        this.startSound.Play();
    }
}
