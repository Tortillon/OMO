using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    public GameObject helperTalk;
    private Collision2D currentCollision;
    public GameObject pointer;
    public GameObject speechCloud;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentCollision != null)
        {
            if (currentCollision.gameObject.CompareTag("mission"))
            {
                pointer.SetActive(false);
                speechCloud.SetActive(true);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mission"))
        {
            helperTalk.SetActive(true);
            currentCollision = collision;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mission"))
        {
            helperTalk.SetActive(false);
            pointer.SetActive(true);
            speechCloud.SetActive(false);
            currentCollision = null;
        }
    }
}
