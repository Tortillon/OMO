using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pickup"))
        {
            collision.gameObject.SetActive(false);
            if (collision.gameObject.name == ("japco")) inventory[0].SetActive(true);
            else if(collision.gameObject.name == ("heart")) inventory[1].SetActive(true);
            
        }
    }
}
