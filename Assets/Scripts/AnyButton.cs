using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using JetBrains.Annotations;
using System.ComponentModel;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.Windows;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class AnyButton : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI titleText;
    public int t = 1;

    private void Start()
    {
        StartCoroutine(FadeTextToFullAlpha(t, titleText));
        StartCoroutine(FadeTextToFullAlpha(t, title));
    }

    private void Update()
    {
        if (UnityEngine.Input.anyKey)
        {
            StartCoroutine(FadeTextToZeroAlpha(t, titleText));
            StartCoroutine(FadeTextToZeroAlpha(t, title));
            StartCoroutine(LoadLevel());
        }
    }
    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
