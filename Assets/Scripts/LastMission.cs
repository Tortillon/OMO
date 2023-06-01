using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LastMission : MonoBehaviour
{
    public GameObject emptyPot;
    public GameObject fullPot;

    public GameObject[] inventoryItem;
    public GameObject inventoryPotion;

    public GameObject helper;

    private bool Full = false;

    private bool Given = false;

    void Update()
    {
        for (int i = 0; i < inventoryItem.Length; i++)
        {
            if (inventoryItem[i].activeSelf) Full = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !Given)
        {
            if (Full == false)
            {
                helper.SetActive(true);
            }
            else
            {
                for (int i = 0; i < inventoryItem.Length; i++)
                {
                    inventoryItem[i].SetActive(false);
                }
               
                inventoryPotion.SetActive(true);
                fullPot.SetActive(true);
                Given = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) helper.SetActive(false);
    }
}
