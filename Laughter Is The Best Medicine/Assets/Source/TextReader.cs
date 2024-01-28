using System.IO;
using UnityEngine;

public class TextReader : MonoBehaviour
{
    public static string[] ReadFile(string filename)
    {
        //Get the file from its directory
        string readFromFilePath = Application.dataPath + "/TextAssets/" + filename + ".txt";

        //ReadAllLines from file and add to an array
        string[] lines = File.ReadAllLines(readFromFilePath);

        /*Debug.Log("LinesArray " + lines.Length);
        foreach(string line in lines) 
        {
            Debug.Log(line);
        }*/
        return lines;
    }
}