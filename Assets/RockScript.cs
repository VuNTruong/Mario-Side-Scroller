using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    // Explosion object to be instantiated
    public GameObject explosion;

    public int number;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        GameObject gameObject = col.gameObject;

        if (gameObject.CompareTag("player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
