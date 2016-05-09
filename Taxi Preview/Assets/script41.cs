using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class script41 : MonoBehaviour
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
        sr = new StreamReader("car_17.txt");
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
        for (int j = 79; j < 100; j++)
        {
            request_x[j] = x_coordinates[99];
            request_y[j] = y_coordinates[99];
        }

        sr = new StreamReader("car_20.txt");
        for (int k = 0; k < 100; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
        //for (int j = 60; j < 79; j++)
        //{
        //    request_x[j] = x_coordinates[78];
        //    request_y[j] = y_coordinates[78];
        //}

        sr = new StreamReader("car_2.txt");
        for (int k = 0; k < 100; k++)
        {
            x_coordinates[k] = float.Parse(sr.ReadLine());
            y_coordinates[k] = float.Parse(sr.ReadLine());
        }
        for (int j = 15; j < 78; j++)
        {
            request_x[j] = x_coordinates[77];
            request_y[j] = y_coordinates[77];
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
