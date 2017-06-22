using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

   // int i = 0;


	public GameObject pauseButton, pausePanel, instructionPanel;
    public AudioClip background_music;
    public string NextLevel;
    public void OnPause() {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void OnUnPause() {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void OnStartAgain ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnLoadScene ()
    {
      //  if (i == 0)
       // {
            Time.timeScale = 1;
            instructionPanel.SetActive(false);


        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = background_music;
        this.GetComponent<AudioSource>().Play();

       // background_music.Play();

        //Application.LoadLevel(SceneManager.GetActiveScene().name);
        //i = i + 1;


        //  }
    }
    public void OnToNextLevel(){
        SceneManager.LoadScene(NextLevel);
    }
}
