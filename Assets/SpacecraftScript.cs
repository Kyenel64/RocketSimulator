using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SpacecraftScript : MonoBehaviour
{
    // Velocity variables
    public float q;
    public float Ve;
    public float Pe;
    public float Pa;
    public float Ae;
    private float mass;
    private float velocity = 0.0f;
    private float acceleration = 0.0f;
    
    // Data gathering variables
    private string[] lines= new string[1000];
    private int linePos = 0;
    private float elapsed = 0f;
    private float graphInterval = 0.5f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = GetComponent<Rigidbody>().mass;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            mass -= Time.deltaTime * q;
            acceleration = (q*Ve+(Pe-Pa)*Ae)/mass;
        }
        if (Input.GetKeyUp("space"))
        {
            acceleration = 0.0f;
        }


        // Calculate velocity
        velocity += Time.deltaTime * acceleration;
        rb.velocity = new Vector3(velocity, 0, 0);

        // Call updateGraph every half second.
        elapsed += Time.deltaTime;
        if (elapsed >= graphInterval)
        {
            elapsed = elapsed % graphInterval;
            updateGraph();
        }
        
    }

    void OnDisable()
    {
        File.WriteAllLinesAsync("Assets/output.txt", lines);
    }

    void updateGraph()
    {
        // Time, distance, velocity, acceleration
        lines[linePos] =  Math.Round(Time.time, 1) + " " + Math.Round(transform.position.x, 2) + " " + Math.Round(velocity, 2) + " " + Math.Round(acceleration, 2);
        linePos++;
    }
}
