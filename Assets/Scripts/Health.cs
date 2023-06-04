using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Rigidbody2D rb;
    public int maxHealth;
    private int currentHealth;
    public Animator[] animators;

    public AudioSource ouchSound;
    public AudioSource uhohSound;

    public Image[] hearts;
    public Sprite heart;

    public GameObject inventoryPotka;

    void Gameover()
    {
        for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isDie", false);
        SceneManager.LoadScene("gameplay");
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isDie", false);
    }

    void Moveon() 
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isSad", false);
    } 

    public void Die(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !inventoryPotka.activeSelf)
        {
            if (currentHealth > 1)
            {
                ouchSound.Play();
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isSad", true);
                TakeDamage(1);
                Invoke("Moveon", 0.3f);
            }

            else
            {
                uhohSound.Play();
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isDie", true);
                Invoke("Gameover", 2f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die(collision);
    }
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth) hearts[i].enabled = true;

            else hearts[i].enabled = false; 
        }
    }
}

