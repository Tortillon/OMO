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


public class Name : MonoBehaviour
{
    public TextMeshProUGUI Hello;
    public TMP_InputField Input;
    public static string PlayerName;
    public List<Sprite> hats = new List<Sprite>();
    public SpriteRenderer spriteRenderer;
    public static int ChosenHat;

    void Start()
    {
        Hello.text = "THIS IS YOUR OMO! CHOOSSE A HAT AND A NAME.";
        
        Input.onValidateInput +=
            delegate (string s, int i, char c) { return char.ToUpper(c); };
    
    }

    public void OnButtonClick(TMP_InputField Input)
    {
        for (int i = 0; i < 3; i++)
        {
            if (spriteRenderer.sprite == hats[i]) ChosenHat = i;
        }

        SceneManager.LoadScene(2);
        PlayerName = Input.text;
    }
    public void Quit()
    {
        Application.Quit();
    }
  
}
