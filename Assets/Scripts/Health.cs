using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Rigidbody2D rb;
    public int maxHealth;
    public int currentHealth;
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
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Die(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && currentHealth > 1) TakeDamage(1);
        
        else
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                animator.SetBool("IsDie", true);
                Invoke("Gameover", 3);
            }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die(collision);
    }
    private void Uptade()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth) hearts[i].enabled = true;

            else hearts[i].enabled = false; 
        }
    }
}

