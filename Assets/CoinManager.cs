using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add to the Create menu (makes it easier to create new instances)
[CreateAssetMenu(menuName = "CoinManager")]

// This is a separate object that stores and provides methods for a counter.

// Note this is an instance of a ScriptableObject, not a MonoBehaviour
public class CoinManager : ScriptableObject
{
    int coin = 0;

    // Methods to allow other scripts to increment and access the count.
    public void incrementCoin()
    {
        coin++;
    }

    // Method to get the current number of coins
    public int getCoin()
    {
        return coin;
    }

    // Method to set the number of coin
    public void setCoin (int numCoin)
    {
        this.coin = numCoin;
    }
}
