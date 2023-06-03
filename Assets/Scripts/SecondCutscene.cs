using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.XR;

public class SecondCutscene : MonoBehaviour
{
    public PlayableDirector timeline;
    public Rigidbody2D rb;
    private bool played = false;
    public GameObject[] Omos;



    void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.CompareTag("Player") && played == false)
        {
            timeline.Play();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            played = true;
            Invoke("Begone", 13);
        }
    }
    void Begone()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        for (int i = 0; i < Omos.Length; i++)
        {
            Omos[i].SetActive(false);
        }
    }
}
