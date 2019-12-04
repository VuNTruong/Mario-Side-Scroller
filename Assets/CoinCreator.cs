using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreator : MonoBehaviour
{
    // Coins GameObject
    public GameObject coin;
    
    // Number of coins to be instantiated
    public int numOfCoins = 20;

    // Start is called before the first frame update
    void Start()
    {
        // Random number between -14 and 14
        float randomXCoordinate;
        
        // Instantiate 20 coins in the game
        for (int i = 0; i < numOfCoins; i++)
        {
            // Create a random x coordinate for the coin
            randomXCoordinate = (float)UnityEngine.Random.Range(-14f, 14f);

            // Instantiate the coin at that location
            GameObject g = Instantiate(coin, new Vector3(randomXCoordinate, 1, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
