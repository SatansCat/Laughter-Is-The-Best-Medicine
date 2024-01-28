using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StandManager : MonoBehaviour
{
    List<JokeStand> stands = new List<JokeStand>();
    public enum JokeType { DadJokes, ShittyPuns };
    string[] Setups;
    string[] Punchlines;
    public int randNum;

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

    private void Start()
    {
        /*foreach (JokeStand stand in stands)
        {
            //
        }*/
        /*
        //This checks for gameobjects with tag "DadJokes"
        if(GameObject.FindWithTag("DadJokes") != null)
        {
            DadJoke = GameObject.FindGameObjectWithTag("DadJokes");
            Setups = TextReader.ReadFile("DadJokesSetups");
            Punchlines = TextReader.ReadFile("DadJokesPunchlines");
            randNum = Random.Range(0, 99);
            //Debug.Log(DadJokeSetups[x] + DadJokesPunchlines[x]);
        }*/
    }

    public void RegisterStand(JokeStand newStand)
    {
        stands.Add(newStand);
        Debug.Log("Stand registered");
    }

    bool isTouched;
    public void Interaction()
    {
        if (!isTouched)
        {
            isTouched = true;
            //Debug.Log(Setups[randNum] + Punchlines[randNum]);
        }
    }
}
