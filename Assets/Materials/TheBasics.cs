using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Numerics;
using UnityEngine;

public class TheBasics : MonoBehaviour // MonoBehaviour inherits transform
{
    public int direction = 1; // "public" means we have access to this in Unity

    // Start is called before the first frame update
    // Executed first, and only once.
    void Start()
    {
        
    }

    // Update is called once per frame
    // Main loop that runs continuously until you end the program (File -> Exit).
    void Update()
    {

        //UnityEngine.Debug.Log("Hello world!");

        //if(Input.GetKeyDown(KeyCode.Escape))

        if (Input.GetKey(KeyCode.W))
        {
            // GetKey(): hold down key -> trigger event
            // GetKeyUp(): hold then release
            // Move in the positive x-direction
            UnityEngine.Debug.Log("You pressed W!");
            transform.Translate(new Vector3(1 * Time.deltaTime, 0, 0)); // x = 1, y = 0, z = 0
            // deltaTime: time it takes to render one frame to the next (smooths out the movement)
        } // end if

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 0, 1 * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0, 0, -1 * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction *= -1;
            // Then multiply coordinates by direction
        }
    } // end Update()
}
