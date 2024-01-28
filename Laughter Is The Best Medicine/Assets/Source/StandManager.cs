using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StandManager : MonoBehaviour
{
    List<JokeStand> stands = new List<JokeStand>();
    public enum JokeType { DadJokes, ShittyPuns };
    //string[] Setups;
    //string[] Punchlines;
    //public int randNum;

    //Making the stand manager a singleton
    public static StandManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void RegisterStand(JokeStand newStand)
    {
        stands.Add(newStand);
        if (newStand.jokeType == JokeType.DadJokes)
        {
            newStand.Setups = TextReader.ReadFile("DadJokesSetups");
            newStand.Punchlines = TextReader.ReadFile("DadJokesPunchlines");
            /*randNum = Random.Range(0, 99);
            Debug.Log(newStand.Setups[randNum] + newStand.Punchlines[randNum]);*/
        }
        Debug.Log("Stand registered");
    }

    /*bool isTouched;
    public void Interaction()
    {
        if (!isTouched)
        {
            isTouched = true;
        }


    }*/
}