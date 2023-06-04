using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

[RequireComponent(typeof(Rigidbody2D))]
public class Heal : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    public GameObject Counter;

    public GameObject inventoryPotka;
    public GameObject victoryPanel;
    public GameObject continueText;

    public GameObject[] Omos;
    public GameObject[] Emes;

    public int emesNumber;
    public int emesHealed;
    public PlayableDirector timeline;

    public Animator[] animators;

    public AudioSource tadaSound;
    public AudioSource healSound;

    private Rigidbody2D rb;
    private bool isHealing = false;
    private bool isPassed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isHealing) CounterText.text = "Emes left to heal " + (emesNumber - emesHealed);
        if (emesHealed >= emesNumber)
        {
            Counter.SetActive(false);
            for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isHappy", true);
            victoryPanel.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("Continue", 3f);
        }
        if (isPassed)
        {
            if (Input.anyKey) victoryPanel.SetActive(false);
        }
    }
    void Continue()
    {
        for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isHappy", false);
        continueText.SetActive(true);
        isPassed = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        emesHealed =0;
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
                    collision.gameObject.SetActive(false);
                    Omos[i].SetActive(true);
                }
            }
            isHealing = true;
            healSound.Play();
            if (timeline.state == PlayState.Paused) emesHealed++;
            if (emesHealed >= emesNumber)
                tadaSound.Play();
            Invoke("StopHappy", 0.35f);
        }
    }
    void StopHappy()
    {
        for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isHappy", false);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
