using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    // Link to Coin Manager in inspector
    public CoinManager coinData;

    // Text component of the GameObject
    Text coin;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the Text component of this object
        coin = GetComponent<Text>();

        // Give a start value
        coin.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Get the number of coin
        coin.text = coinData.getCoin().ToString();
    }
}
