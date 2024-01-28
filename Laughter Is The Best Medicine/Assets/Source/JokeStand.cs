using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeStand : MonoBehaviour
{
    [SerializeField] StandManager.JokeType jokeType;
    private string[] setups;
    private string[] punchlines;

    public string[] Setups
    { 
        get { return setups; } 
        set { setups = value; } 
    }
    public string[] Punchlines
    { 
        get { return punchlines; } 
        set { punchlines = value; } 
    }
    void Start()
    {
        StandManager.instance.RegisterStand(this);
        Debug.Log("Stand Added to List");
    }
}
