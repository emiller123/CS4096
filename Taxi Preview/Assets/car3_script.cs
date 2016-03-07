using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class car3_script : MonoBehaviour {
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
        //transform.position = new Vector3(y_coordinates[move_index], 0, x_coordinates[move_index]);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("right"))
        //{
        //    transform.Translate(new Vector3(1, 0, 0));
        //    //transform.Translate = new Vector3(0, 1, 0);
        //}
        if (Input.GetKeyDown("left"))
        {
            move_index--;
            transform.position = new Vector3(y_coordinates[move_index], 0, x_coordinates[move_index]);
            //transform.translate = new vector3(0, 1, 0);
        }
        //else if (Input.GetKeyDown("down"))
        //{
        //    transform.Translate(new Vector3(0, 0, -1));
        //    //transform.Translate = new Vector3(0, 1, 0);
        //}

        else if (Input.GetKeyDown("right"))
        {
            move_index++;
            //float new_x = float.Parse(sr.ReadLine());
            //float new_y = float.Parse(sr.ReadLine());
            transform.position = new Vector3(y_coordinates[move_index], 0, x_coordinates[move_index]);
            //transform.translate(new vector3(0, 0, 1));
            //transform.translate = new vector3(0, 1, 0);
        }

    }
}
