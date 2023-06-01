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
    public Animator animator;

    public Image[] hearts;
    public Sprite heart;

    public GameObject inventoryPotka;

    void Gameover()
    {
        animator.SetBool("IsDie", false);
        SceneManager.LoadScene("gameplay");
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetBool("Sad", false);
    }

    void Moveon() 
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator.SetBool("isSad", false);
    } 

    public void Die(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !inventoryPotka.activeSelf)
        {
            if (currentHealth > 1)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                animator.SetBool("isSad", true);
                TakeDamage(1);
                Invoke("Moveon", 0.3f);
            }

            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                animator.SetBool("isDie", true);
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

