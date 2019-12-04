using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    // Rigidbody2D component of the object
    Rigidbody2D rb;

    // Left button
    GameObject leftButton;

    // Right button
    GameObject rightButton;

    // Jump button 
    GameObject jumpButton;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D of the object
        rb = GetComponent<Rigidbody2D>();

        // Get Button component for the leftButton
        leftButton = GameObject.FindWithTag("left");
        leftButton.GetComponent<Button>().onClick.AddListener(TaskOnClick); ;

        // Get Button component for the rightButton
        rightButton = GameObject.FindWithTag("right");
        rightButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);

        // Get Button component 
        jumpButton = GameObject.FindWithTag("jump");
        jumpButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
