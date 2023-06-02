using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Heal : MonoBehaviour
{

    public GameObject inventoryPotka;
    public GameObject victoryPanel;
    public GameObject continueText;
    public int emesNumber;
    public int emesHealed;

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
            collision.gameObject.SetActive(false);
            emesHealed++;
            Invoke("StopHappy", 0.35f);
        }
    }
    void StopHappy()
    {
        for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isHappy", false);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
