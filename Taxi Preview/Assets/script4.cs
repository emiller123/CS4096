using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class script4 : MonoBehaviour
{
    StreamReader sr;
    StreamReader sr2;
    float[] x_coordinates = new float[100];
    float[] y_coordinates = new float[100];
    float[] request_x = new float[100];
    float[] request_y = new float[100];
    int move_index = 0;


    void Start()
    {
        sr = new StreamReader("car_3.txt");
        sr2 = new StreamReader("requests.txt");
        for (int k = 0; k < 100; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
        for (int j = 0; j < 100; j++)
        {
            request_x[j] = float.Parse(sr2.ReadLine());
            request_y[j] = float.Parse(sr2.ReadLine());
        }
        transform.position = new Vector3(y_coordinates[move_index], 0, x_coordinates[move_index]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            move_index--;
            transform.position = new Vector3(y_coordinates[move_index+1], 0, x_coordinates[move_index+1]);
        }

        else if (Input.GetKeyDown("right"))
        {
            move_index++;
            transform.position = new Vector3(y_coordinates[move_index+1], 0, x_coordinates[move_index+1]);
        }

    }
}
