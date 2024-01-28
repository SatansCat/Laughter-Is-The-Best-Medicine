using ReadSpeaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StandManager;

public class Bed : MonoBehaviour
{
    private Patient m_bedPatient;
    [SerializeField] private GameObject timer;
    [SerializeField] private bool m_occupied;
    public TTSSpeaker speaker;
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
        TTS.Init();
    }

    public void Interaction()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().HasJoke == true)
        {
            //Read the joke out loud
            //Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().TheJoke);
            TTS.Say(GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().TheJoke, speaker);
            //Remove joke from player
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().HasJoke = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().TheJoke = null;
            //Make sure no new lines start playing until the current is done
            //Below line will not exit until the joke is finished, this was in the tutorial but I don't think we would need it.
            //yield return new WaitUntil(() => !speaker.audioSource.isPlaying);
        }
        else
        {
            Debug.Log("Not holding joke");
        }
    }
}
