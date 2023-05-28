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

    void Start()
    {
        Hello.text = "THIS IS YOUR OMO! CHOOSSE A HAT AND A NAME.";
        
        Input.onValidateInput +=
            delegate (string s, int i, char c) { return char.ToUpper(c); };
    
    }

    public void OnButtonClick(TMP_InputField Input)
    {
         StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
