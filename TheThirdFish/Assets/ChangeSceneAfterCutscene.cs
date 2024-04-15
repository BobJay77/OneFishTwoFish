using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Playables;

public class ChangeSceneAfterCutscene : MonoBehaviour
{
    private float time = 0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > GetComponent<PlayableDirector>().duration) 
        {
            if (SceneManager.GetActiveScene().name == "Intro Cutscene")
            {
                SceneManager.LoadScene("Main");
            }

            if (SceneManager.GetActiveScene().name == "Win Cutscene" || SceneManager.GetActiveScene().name == "Lose Cutscene")
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadSceneAsync("Menu");
            }


        }
    }
}
