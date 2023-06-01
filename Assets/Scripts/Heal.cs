using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Heal : MonoBehaviour
{

    public GameObject inventoryPotka;
    public GameObject vicotryPanel;
    private Collision2D currentCollision;
    public int emesNumber;
    public int emesHealed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (inventoryPotka.activeSelf && emesHealed < emesNumber)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.SetActive(false);
                emesHealed++;
                Debug.Log(emesHealed);
            }
        }
        else
        {
            vicotryPanel.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
    }
}
