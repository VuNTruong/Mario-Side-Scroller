using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Rigidbody2D component of the object
    Rigidbody2D rb;

    // Speed of the movement
    public float speed = 0.04f;

    // Force to be added to the player when it jumps
    public float force = 1f;

    // Force to be added to the player when it moves
    public float forceMove = 0.7f;

    // Animator component of the object
    Animator anim;

    // Boolean value to keep track of if the player is on ground or not
    private bool onGround;

    // Number of coins collected
    public int coinsCollected;

    // Number of lives remaining
    public int lives;

    // CoinManager component to keep track of number of coins
    public CoinManager coinManager;

    // public access to the LivesManager component
    public LivesManager liveData;

    // Explosion GameObject 
    public GameObject explosion;

    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D of the object
        rb = GetComponent<Rigidbody2D>();

        // Get the Animator of the object
        anim = GetComponent<Animator>();

        // Set the Animator state initially to false
        // Since the right animation will be played first
        anim.SetBool("left", false);

        // Set the onGround value initially to true
        onGround = true;

        // Set the initial number of coins to 0
        coinsCollected = 0;
        coinManager.setCoin(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if key is pressed or not
        // If the right arrow key is pressed, bring the player to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Add positive impulse force in the x direction to make the player move to the right
            rb.AddForce(new Vector2(forceMove, 0), ForceMode2D.Impulse);

            // Set the animation to right walk animation by setting the "left" param to false
            anim.SetBool("left", false);
        }

        // If the left arrow key is pressed, bring the player to the left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Add negative impulse force in the x direction to make the player move to the left
            rb.AddForce(new Vector2(-forceMove, 0), ForceMode2D.Impulse);

            // Set the animation to left walk animation by setting the "left" param to true
            anim.SetBool("left", true);
        }

        // If the space key is pressed, add force to the player in the y direction and make it jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Only let the player jump if is on ground
            if (onGround)
            { 
                // Add impulse force in the y direction
                rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);

                // Set the onGround value to false as no longer on ground
                onGround = false;
            }
        }

        // Check if the player is more than 15 or less than -15 or not
        // If it is, bring the player to the opposite side
        // If the x coordinate of the player is greater than 15
        if (rb.position.x > 15)
        {
            // Bring the player to the place where x coordinate is -15
            rb.position = new Vector2(-15, 0);
        }
        // If the x coordinate of the player is less than -15
        else if (rb.position.x < -15)
        {
            // Bring the player to the place where x coordinate is 15
            rb.position = new Vector2(15, 0);
        }

        if (liveData.getLives() == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }

        if (coinManager.getCoin() == 20)
        {
            GameObject canvas;

            canvas = GameObject.FindWithTag("canvas");

            GameObject uiObj = Instantiate<GameObject>(image, new Vector3(337.4f, 100f, 0), Quaternion.identity);
            uiObj.transform.SetParent(canvas.transform);
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        // Get the object get collided with
        GameObject gameObject = col.gameObject;

        // Compare tag to see if it is the ground object or not
        if (gameObject.CompareTag("ground"))
        {
            // Set the onGround value back to true as coming back to ground
            onGround = true;
        }

        if (gameObject.CompareTag("rock"))
        {

            // Also decrement lives in liveData
            liveData.decrementLive();

        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        // Get the object get collided with
        GameObject gameObject = col.gameObject;

        // Compare tag to see if the object is collided with the coin or not
        if (gameObject.CompareTag("coin"))
        {
            Destroy(gameObject);

            coinsCollected += 1;

            Debug.Log(coinsCollected);

            // Increase the number of coins
            coinManager.incrementCoin();
        }
    }
}
