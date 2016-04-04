using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class script24 : MonoBehaviour
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
        sr = new StreamReader("car_14.txt");
        for (int k = 0; k < 100; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
        for (int j = 0; j < 100; j++)
        {
            request_x[j] = 1000;
            request_y[j] = 1000;
        }
        for (int j = 0; j < 10; j++)
        {
            request_x[j] = x_coordinates[9];
            request_y[j] = y_coordinates[9];
        }
        for (int j = 74; j < 82; j++)
        {
            request_x[j] = x_coordinates[81];
            request_y[j] = y_coordinates[81];
        }

        sr = new StreamReader("car_1.txt");
        for (int k = 0; k < 100; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
        for (int j = 11; j < 16; j++)
        {
            request_x[j] = x_coordinates[15];
            request_y[j] = y_coordinates[15];
        }
        for (int j = 40; j < 47; j++)
        {
            request_x[j] = x_coordinates[46];
            request_y[j] = y_coordinates[46];
        }
        for (int j = 61; j < 69; j++)
        {
            request_x[j] = x_coordinates[68];
            request_y[j] = y_coordinates[68];
        }

        sr = new StreamReader("car_5.txt");
        for (int k = 0; k < 100; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
        for (int j = 20; j < 35; j++)
        {
            request_x[j] = x_coordinates[34];
            request_y[j] = y_coordinates[34];
        }
        for (int j = 43; j < 53; j++)
        {
            request_x[j] = x_coordinates[52];
            request_y[j] = y_coordinates[52];
        }
        for (int j = 88; j < 99; j++)
        {
            request_x[j] = x_coordinates[98];
            request_y[j] = y_coordinates[98];
        }
        transform.position = new Vector3(request_y[move_index], 0, request_x[move_index]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            move_index--;
            transform.position = new Vector3(request_y[move_index], 0, request_x[move_index]);
        }

        else if (Input.GetKeyDown("right"))
        {
            move_index++;
            transform.position = new Vector3(request_y[move_index], 0, request_x[move_index]);
        }

    }
}
