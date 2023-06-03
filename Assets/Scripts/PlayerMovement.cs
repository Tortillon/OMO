using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;
    public Animator[] animators;

    public bool isDash;
    private float dashSpeed = 15f;
    
    private float dashLength = .2f;
    private float dashCooldown = .4f;

    private float dashTime;
    private float dashCoolTime;

    private float activeSpeed;

    public GameObject[] Hats;

    Vector2 movement;

    void Start()
    {
        activeSpeed = speed;
        Hats[Name.ChosenHat].SetActive(true);
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        for (int i = 0; i < animators.Length; i++) animators[i].SetFloat("Horizontal", movement.x);
        for (int i = 0; i < animators.Length; i++) animators[i].SetFloat("Vertical", movement.y);
        for (int i = 0; i < animators.Length; i++) animators[i].SetFloat("Speed", movement.sqrMagnitude);


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolTime <= 0 && dashTime <= 0)
            {
                for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isDash", true);
                activeSpeed += dashSpeed;
                dashTime = dashLength;
            }
        }

            if (dashTime > 0)
            {
                dashTime -= Time.deltaTime;

                if (dashTime <= 0)
                {
                    for (int i = 0; i < animators.Length; i++) animators[i].SetBool("isDash", false);
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
