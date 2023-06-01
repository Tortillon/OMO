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

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (emesHealed >= emesNumber)
        {
            victoryPanel.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("Continue", 1);
        }
    }
    void Continue()
    {
        continueText.SetActive(true);
        if (Input.anyKey) victoryPanel.SetActive(false);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        emesHealed--;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (inventoryPotka.activeSelf && collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            emesHealed++;
        }
    }
}
