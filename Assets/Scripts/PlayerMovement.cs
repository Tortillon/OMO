using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;
    public Animator PlayerAnimator;
    public Animator HatBAnimator;


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

        PlayerAnimator.SetFloat("Horizontal", movement.x);
        PlayerAnimator.SetFloat("Vertical", movement.y);
        PlayerAnimator.SetFloat("Speed", movement.sqrMagnitude);

        HatBAnimator.SetFloat("Horizontal", movement.x);
        HatBAnimator.SetFloat("Vertical", movement.y);
        HatBAnimator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolTime <= 0 && dashTime <= 0)
            {
                PlayerAnimator.SetBool("isDash", true);
                HatBAnimator.SetBool("isDash", true);
                activeSpeed += dashSpeed;
                dashTime = dashLength;
            }
        }

            if (dashTime > 0)
            {
                dashTime -= Time.deltaTime;

                if (dashTime <= 0)
                {
                    PlayerAnimator.SetBool("isDash", false);
                    HatBAnimator.SetBool("isDash", false);
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
