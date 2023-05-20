using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HatSwap : MonoBehaviour
{
    public List<Sprite> hats = new List<Sprite>();
    public SpriteRenderer spriteRenderer;

    private int Current;

    public void Next()
    {
        Current++;
        if (Current >= hats.Count)
        {
            Current = 0;
        }
        spriteRenderer.sprite = hats[Current];
    }
    public void Previous()
    {
        Current--;
        if (Current < 0)
        {
            Current = hats.Count-1;
        }
        spriteRenderer.sprite = hats[Current];
    }
}
