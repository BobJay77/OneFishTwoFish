using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelinePlayer : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject controlPanel;
    private void Awake()
    {
        director.played += Director_Played;
        director.stopped += Director_Stopped;
        director.enabled = false;
    }

    private void Director_Played(PlayableDirector obj)
    {
        controlPanel.SetActive(false);
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        SceneManager.LoadScene("Main");
    }

    public void StartTimeline()
    {
        director.enabled = true;
        director.Play();

    }
}