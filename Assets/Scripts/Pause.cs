using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{

    public GameObject pause;
    public GameObject panel;
    public CanvasRenderer cr;
    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Click()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
