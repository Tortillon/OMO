using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class LastMission : MonoBehaviour
{
    public GameObject emptyPot;
    public GameObject fullPot;

    public GameObject[] inventoryItem;
    public GameObject inventoryPotion;

    public GameObject helper;

    public PlayableDirector timeline;
    public Rigidbody2D rb;
    public GameObject music1;
    public GameObject music2;

    private bool Full = false;

    private bool Given = false;

    void Update()
    {
         if (inventoryItem[0].activeSelf && inventoryItem[1].activeSelf && inventoryItem[2].activeSelf) Full = true;
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
                timeline.Play();
                Given = true;
                music2.SetActive(false);
                music1.SetActive(true);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) helper.SetActive(false);
    }
}
