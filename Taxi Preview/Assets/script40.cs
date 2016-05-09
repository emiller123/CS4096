using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class script40 : MonoBehaviour
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
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        sr = new StreamReader("car_16.txt");
        for (int k = 0; k < 100; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
        for (int j = 0; j < 100; j++)
        {
            request_x[j] = 10000;
            request_y[j] = 10000;
        }
        for (int j = 1; j < 40; j++)
        {
            request_x[j] = x_coordinates[39];
            request_y[j] = y_coordinates[39];
        }

        sr = new StreamReader("car_3.txt");
        for (int k = 0; k < 100; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
        //for (int j = 58; j < 84; j++)
        //{
          //  request_x[j] = x_coordinates[83];
          //  request_y[j] = y_coordinates[83];
        //}

        sr = new StreamReader("car_1.txt");
        for (int k = 0; k < 100; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
        //for (int j = 28; j < 58; j++)
        //{
          //  request_x[j] = x_coordinates[57];
          //  request_y[j] = y_coordinates[57];
       // }
        sr = new StreamReader("car_5.txt");
        for (int k = 0; k < 100; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
        for (int j = 70; j < 100; j++)
        {
            request_x[j] = x_coordinates[99];
            request_y[j] = y_coordinates[99];
        }
        //for (int j = 81; j < 99; j++)
        //{
        //    request_x[j] = x_coordinates[98];
        //    request_y[j] = y_coordinates[98];
        //}
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
