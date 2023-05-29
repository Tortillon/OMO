using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowName : MonoBehaviour
{
    public TextMeshProUGUI playerName;

    private void Start()
    {
        UpdatePlayerName();
    }

    public void UpdatePlayerName()
    {
        playerName.text = Name.PlayerName;
    }
}