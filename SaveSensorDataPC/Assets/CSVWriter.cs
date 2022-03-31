using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CSVWriter : MonoBehaviour
{
    string filename = "";
    public Text text;


    [System.Serializable]
    public class Coordinates
    {

        public TMPro.TMP_Text text;

    }
    [System.Serializable]

    public class CoordinatesList
    {
        public Coordinates[] coordinates;
    }


    public CoordinatesList myCoordinatesList = new CoordinatesList();


    void Start()
    {
        filename = Application.dataPath + "/test.csv";
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("X,Y,Z");
        tw.Close();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            timer();
    }

    public void timer()
    {
        Invoke("WriteToCSV", 2.0f);
    }

    public void WriteToCSV()
    {
        

            TextWriter tw = new StreamWriter(filename, true);
        text.text = "Acceleration Data : " + Input.acceleration.ToString();
            tw.WriteLine(Input.acceleration.x + "," + Input.acceleration.y + "," + Input.acceleration.z);
        Debug.Log(Input.acceleration);
            tw.Close();

    }
}