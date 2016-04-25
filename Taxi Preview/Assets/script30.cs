﻿using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class script30 : MonoBehaviour {
    StreamReader sr;
    float[] distance_values = new float[100];
    int move_index = 0;

    private string mileage = "0";
    private string fuel = "0";
    private string cost= "0";
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable
    void OnGUI()
    {
        guiStyle.fontSize = 20; //change the font size
        guiStyle.normal.textColor = Color.white;
        GUI.Box(new Rect(504, 50, 190, 100),"");
        GUI.Label(new Rect(505, 50, 130, 130), "Analytics Information", guiStyle);
        GUI.Label(new Rect(505, 75, 130, 130), "Mileage: " + mileage,guiStyle);
        GUI.Label(new Rect(505, 100, 130, 130), "Fuel: " + fuel, guiStyle);
        GUI.Label(new Rect(505, 125, 200, 200), "Cost: " + cost, guiStyle);
    }
    // Use this for initialization
    void Start()
    {
        sr = new StreamReader("distance.txt");
        distance_values[0] = 0.002816f;
        for (int k = 1; k < 100; k++)
        {
            distance_values[k] = distance_values[k - 1] + 0.002816f*1000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            move_index--;
            mileage = Math.Round(distance_values[move_index],3).ToString();
            fuel = Math.Round((distance_values[move_index] / 20), 3).ToString();
            cost = Math.Round((distance_values[move_index] / 20 * 2.5), 3).ToString();
        }

        else if (Input.GetKeyDown("right"))
        {
            move_index++;
            mileage = Math.Round(distance_values[move_index], 3).ToString();
            fuel = Math.Round((distance_values[move_index] / 20),3).ToString();
            cost = Math.Round((distance_values[move_index] / 20 * 2.5),3).ToString();
        }
    }

}
