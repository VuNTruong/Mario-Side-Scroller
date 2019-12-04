using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUIImage : MonoBehaviour
{
    GameObject canvas;
    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("canvas");    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            GameObject uiObj = Instantiate<GameObject>(image, new Vector3(337.4f, 100f, 0), Quaternion.identity);
            uiObj.transform.SetParent(canvas.transform);
        }
    }
}
