using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    int totalCoins;
    public TextMeshProUGUI coinTextNumber;

    private void Start()
    {
        
    }

    public void updateCoins(int coindropped)
    {
        totalCoins += coindropped;
        coinTextNumber.text = totalCoins.ToString();
    }
}
