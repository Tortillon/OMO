using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    private bool isPaused;

    public GameObject pause;
    public GameObject panel;
    public CanvasRenderer cr;
    public void Resume()
    {
        panel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void Click()
    {
        panel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
