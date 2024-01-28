using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StandManager;

public class Bed : MonoBehaviour
{
    private Patient m_bedPatient;
    [SerializeField] private GameObject timer;
    [SerializeField] private bool m_occupied;
    //disease icon

    public Patient BedPatient
    {
        get { return m_bedPatient; }
        set { m_bedPatient = value; }
    }

    public bool Occupied
    {
        get { return m_occupied; }
        set { m_occupied = value; }
    }


    //Register bed to manager
    void Start()
    {
        BedManager.instance.RegisterBed(this);
    }

    public void Interaction()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().HasJoke == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().HasJoke = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().TheJoke = null;
        }
        else
        {
            Debug.Log("Not holding joke");
        }
    }
}
