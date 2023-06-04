using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class Heal : MonoBehaviour
{
    public TextMeshProUGUI Counter;

    public GameObject inventoryPotka;
    public GameObject victoryPanel;
    public GameObject continueText;

    public GameObject[] Omos;
    public GameObject[] Emes;

    public int emesNumber;
    public static int emesHealed;
    public PlayableDirector timeline;

    public Animator[] animators;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (emesHealed >= emesNumber)
        {
            for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isHappy", true);
            victoryPanel.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("Continue", 3f);
        }
    }
    void Continue()
    {
        for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isHappy", false);
        continueText.SetActive(true);
        if (Input.anyKey) victoryPanel.SetActive(false);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        emesHealed--;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (inventoryPotka.activeSelf && collision.gameObject.CompareTag("Enemy"))
        {
            for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isHappy", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            for (int i = 0; i < Emes.Length; i++)
            {
                if (Emes[i] == collision.gameObject)
                {
                    Debug.Log(Omos[i]);
                    collision.gameObject.SetActive(false);
                    Omos[i].SetActive(true);
                }
            }
            
            if (timeline.state == PlayState.Paused) emesHealed++;
            Invoke("StopHappy", 0.35f);
        }
    }
    void StopHappy()
    {
        for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isHappy", false);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
