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



    void Gameover()
    {
        animator.SetBool("IsDie", false);
        SceneManager.LoadScene("gameplay");
    }

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log(currentHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Die(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && currentHealth > 1)
        {
            TakeDamage(1);
            Debug.Log(currentHealth);
        }

        else if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.freezeRotation = true;
            animator.SetBool("isDie", true);
            Debug.Log("le");
            Invoke("Gameover", 3);
        }
        else return;

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

