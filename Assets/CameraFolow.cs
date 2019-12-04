using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    // GameObject that the camera should follow
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set the x of the camera to the player since the camera will move with the
        // player when the player move left or right
        // The y and z of the camera should stay the same

        // Get the x coordinate of the player and set it to the camera
        float x = player.transform.position.x;

        // Get camera z and y (since this will not change)
        float z = transform.position.z;
        float y = transform.position.y;

        // Move camera to that position
        transform.position = new Vector3(x, y, z);
    }
}
