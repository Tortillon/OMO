using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory;
    public GameObject helperPickup;
    private Collision2D currentCollision;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentCollision!=null )
        {
            if (currentCollision.gameObject.CompareTag("pickup"))
            {
                if (currentCollision.gameObject.name == ("japco")) inventory[0].SetActive(true);
                else if (currentCollision.gameObject.name == ("heart")) inventory[1].SetActive(true);
                currentCollision.gameObject.SetActive(false);
            }
            
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pickup"))
        {
            helperPickup.SetActive(true);
            currentCollision = collision;
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                collision.gameObject.SetActive(false);
                if (collision.gameObject.name == ("japco")) inventory[0].SetActive(true);
                else if (collision.gameObject.name == ("heart")) inventory[1].SetActive(true);
            }*/
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pickup"))
        {
            helperPickup.SetActive(false);
            currentCollision=null;
        }
        
    }
}
