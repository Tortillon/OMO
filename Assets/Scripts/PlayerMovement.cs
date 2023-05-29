using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;
    public Animator animator;

    public bool isDash;
    private float dashSpeed = 15f;
    
    private float dashLength = .2f;
    private float dashCooldown = .4f;

    private float dashTime;
    private float dashCoolTime;

    private float activeSpeed;

    Vector2 movement;

    void Start()
    {
        activeSpeed = speed;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolTime <= 0 && dashTime <= 0)
            {
                animator.SetBool("isDash", true);
                activeSpeed += dashSpeed;
                dashTime = dashLength;
            }
        }

            if (dashTime > 0)
            {
                dashTime -= Time.deltaTime;

                if (dashTime <= 0)
                {
                    animator.SetBool("isDash", false);
                    activeSpeed = speed;
                    dashCoolTime = dashCooldown;
                }
            }

            if (dashCoolTime > 0)
            {
                dashCoolTime -= Time.deltaTime;
            }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * activeSpeed * Time.fixedDeltaTime);
    }

    
}
