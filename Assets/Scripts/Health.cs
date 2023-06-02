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
    public Animator PlayerAnimator;
    public Animator HatBAnimator;


    public Image[] hearts;
    public Sprite heart;

    public GameObject inventoryPotka;

    void Gameover()
    {
        PlayerAnimator.SetBool("IsDie", false);
        HatBAnimator.SetBool("IsDie", false);
        SceneManager.LoadScene("gameplay");
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        PlayerAnimator.SetBool("Sad", false);
        HatBAnimator.SetBool("Sad", false);
    }

    void Moveon() 
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        PlayerAnimator.SetBool("isSad", false);
        HatBAnimator.SetBool("isSad", false);
    } 

    public void Die(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !inventoryPotka.activeSelf)
        {
            if (currentHealth > 1)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                PlayerAnimator.SetBool("isSad", true);
                HatBAnimator.SetBool("isSad", true);
                TakeDamage(1);
                Invoke("Moveon", 0.3f);
            }

            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                PlayerAnimator.SetBool("isDie", true);
                HatBAnimator.SetBool("isDie", true);
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

