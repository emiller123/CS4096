using UnityEngine;
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
    private GUIStyle title = new GUIStyle();
    private GUIStyle arrows = new GUIStyle();
    void OnGUI()
    {
        guiStyle.fontSize = 20; //change the font size
        guiStyle.normal.textColor = Color.white;
        title.fontSize = 50; //change the font size
        title.normal.textColor = Color.black;
        arrows.fontSize = 15; //change the font size
        arrows.normal.textColor = Color.black;
        GUI.Box(new Rect(504, 50, 190, 100),"");
        GUI.Label(new Rect(105, 50, 130, 130), "Ride Sharing", title);
        GUI.Label(new Rect(140, 120, 130, 130), "Simulator", title);
        GUI.Label(new Rect(505, 50, 130, 130), "Analytics Information", guiStyle);
        GUI.Label(new Rect(505, 75, 130, 130), "Mileage: " + mileage,guiStyle);
        GUI.Label(new Rect(505, 100, 130, 130), "Fuel: " + fuel, guiStyle);
        GUI.Label(new Rect(505, 125, 200, 200), "Cost: " + cost, guiStyle);
        GUI.Label(new Rect(550, 325, 200, 200), "Use Arrow Keys To Navigate Through Time", arrows);
        GUI.Label(new Rect(575, 360, 200, 200), "Backward", arrows);
        GUI.Label(new Rect(750, 360, 200, 200), "Forward", arrows);
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
