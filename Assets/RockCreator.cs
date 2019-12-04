using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCreator : MonoBehaviour
{
    // Rock GameObject
    public GameObject rock;

    // Number of rocks to be instantiated
    public int numOfRocks = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        // Random number between -14 and 14
        float randomXCoordinate;

        // Instantiate 10 rocks in the game
        for (int i = 0; i < numOfRocks; i++)
        {
            // Create a random x coordinate for the rock
            randomXCoordinate = (float)UnityEngine.Random.Range(-14f, 14f);

            // Instantiate the rock at that location
            GameObject g = Instantiate(rock, new Vector3(randomXCoordinate, -0.03f, 0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
