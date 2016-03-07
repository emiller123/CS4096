using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class car1 : MonoBehaviour {
    StreamReader sr;
    float[] x_coordinates = new float[100];
    float[] y_coordinates = new float[100];
    int move_index = 0;


    void Start()
    {
        sr = new StreamReader("car_1.txt");
        for (int k = 0; k < 20; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            move_index--;
            transform.position = new Vector3(y_coordinates[move_index], 0, x_coordinates[move_index]);
        }

        else if (Input.GetKeyDown("right"))
        {
            move_index++;
            transform.position = new Vector3(y_coordinates[move_index], 0, x_coordinates[move_index]);
        }

    }
}
