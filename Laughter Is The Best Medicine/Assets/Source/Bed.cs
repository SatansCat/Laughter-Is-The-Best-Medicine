using ReadSpeaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StandManager;

public class Bed : MonoBehaviour
{
    private Patient m_bedPatient;
    public GameObject patientObject;
    public GameObject patientPosition;
    [SerializeField] private GameObject timer;
    [SerializeField] private bool m_occupied;
    public TTSSpeaker speaker;
    Player_Movement movementScript;
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
        movementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
    }

    public void Interaction1()
    {
        if (movementScript.HasJoke == true)
        {
            //if bed is occupied try to solve simptom
            if (m_occupied)
                AttemptCure(movementScript.HeldJokeType);

            //Read the joke out loud
            //Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().TheJoke);
            TTS.Say(movementScript.TheJoke, speaker);
            //Remove joke from player
            movementScript.HasJoke = false;
            movementScript.TheJoke = null;
            //Make sure no new lines start playing until the current is done
            //Below line will not exit until the joke is finished, this was in the tutorial but I don't think we would need it.
            //yield return new WaitUntil(() => !speaker.audioSource.isPlaying);
        }
        else
        {
            Debug.Log("Not holding joke");
        }
    }
    public void Interaction2()
    {
        Debug.Log("Q pressed");
    }

    public void AttemptCure(JokeType type)
    {
        foreach(KeyValuePair<Disease.Symptoms,bool> k in m_bedPatient.Illness.symptoms)
        {
            //Symptom isn't cured yet
            if (k.Value == false)
            {
                //Check if type matches
                if (BedManager.instance.cures.TryGetValue(k.Key, out JokeType value) && value == type)
                {
                    m_bedPatient.Illness.symptoms[k.Key] = true;
                    break;
                }
            }
        }
    }
}
