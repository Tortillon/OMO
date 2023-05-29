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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("kupa");
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i].SetActive(true);
                Debug.Log("dupa");
            }
        }
    }
}
