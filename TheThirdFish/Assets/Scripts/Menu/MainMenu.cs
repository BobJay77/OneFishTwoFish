using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject information;
    public GameObject buttons;
    public PlayableDirector playableDirector;
    public bool init = false;

    public void StartGame()
    {
        init= true;
        buttons.SetActive(false);

    }
    public void Instructions()
    {
        information.SetActive(true);
    }
    public void GoBack()
    {
        information.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if (init)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            playableDirector.played += Director_Played;
            playableDirector.stopped += Director_Stopped;
            //playableDirector.enabled = false;
            playableDirector.Play();
           
        }

        if (SceneManager.GetActiveScene().name == "Win")
        {
            information = null;
            buttons = null;

            playableDirector.played += Director_Played;
            playableDirector.stopped += Director_Stopped;
            //playableDirector.enabled = false;
            playableDirector.Play();

        }


    }
    private void Director_Played(PlayableDirector obj)
    {
        buttons.SetActive(false);
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        SceneManager.LoadScene("Menu");
        buttons.SetActive(true);
    }

}
