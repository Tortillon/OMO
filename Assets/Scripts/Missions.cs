using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Missions : MonoBehaviour
{
    public GameObject speechCloud;
    public GameObject pointer;
    public GameObject inventoryItem;

    public GameObject helperTalk;
    public GameObject helperGive;

    private Collision2D currentCollision;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            if (currentCollision!=null && currentCollision.gameObject.CompareTag("Player") && !inventoryItem.activeSelf)
            {
                pointer.SetActive(false);
                speechCloud.SetActive(true);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (inventoryItem.activeSelf)
            {
                helperGive.SetActive(true);
                Debug.Log("dupa");
            }
            else
            { 
                helperTalk.SetActive(true);
                Debug.Log("kupa");

            }
            currentCollision = collision;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (inventoryItem.activeSelf) helperGive.SetActive(false);
            else
            {
                helperTalk.SetActive(false);
                pointer.SetActive(true);
                speechCloud.SetActive(false);
            }
            currentCollision = null;
        }
    }
}
