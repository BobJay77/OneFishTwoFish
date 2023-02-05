using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject information;

    public void StartGame()
    {
        
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

}
