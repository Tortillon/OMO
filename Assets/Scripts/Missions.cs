using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Missions : MonoBehaviour
{
    public GameObject speechCloud;
    public GameObject pointer;
    public GameObject inventoryItem;
    public GameObject inventoryPotion;

    public GameObject helperTalk;
    public GameObject helperGive;

    public Animator animator;
    public AudioSource yaySound;

    private Collision2D currentCollision;
    private bool Given = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentCollision != null && Given == false)
        {
            if (!inventoryItem.activeSelf)
            {
                pointer.SetActive(false);
                speechCloud.SetActive(true);
            }
            else
            {
                yaySound.Play();
                pointer.SetActive(false);
                helperGive.SetActive(false);
                inventoryItem.SetActive(false);
                inventoryPotion.SetActive(true);
                animator.SetBool("isGiven", true);
                Given = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Given == false)
        {
            if (inventoryItem.activeSelf)
            {
                helperGive.SetActive(true);
            }
            else
            { 
                helperTalk.SetActive(true);
            }
            currentCollision = collision;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (inventoryItem.activeSelf && Given == false) helperGive.SetActive(false);
            else if (!inventoryItem.activeSelf && Given == false)
            {
                helperTalk.SetActive(false);
                pointer.SetActive(true);
                speechCloud.SetActive(false);
            }
            else if (!inventoryItem.activeSelf && Given == true)
            {
                helperTalk.SetActive(false);
                pointer.SetActive(false);
                speechCloud.SetActive(false);
            }
            currentCollision = null;
        }
    }
}
