using ReadSpeaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StandManager;

public class Bed : MonoBehaviour
{
    private Patient m_bedPatient;
    public GameObject patientObject;
    public GameObject patientPosition;
    public float SpeedModifier = 1;
    public Slider timer;
    [SerializeField] private bool m_occupied;
    public TTSSpeaker speaker;
    Player_Movement movementScript;
    [SerializeField] private AudioClip CorrectJoke;
    [SerializeField] private AudioClip FullHeal;
    [SerializeField] private AudioClip WrongJoke;
    [SerializeField] private AudioClip DyingNoise;
    [SerializeField] private AudioSource PatientSounds;
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

    void Update()
    {
        if(m_occupied && m_bedPatient != null)
        {
            Debug.Log("TIME PASSED " +timer);
            timer.value -= 1 * SpeedModifier;
            if(timer.value <= 1)
            {
                KillPatient();
            }
        }
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
                    //CorrectJoke.Play();
                    m_bedPatient.Illness.symptoms[k.Key] = true;
                    foreach(KeyValuePair<Disease.Symptoms, bool> b in m_bedPatient.Illness.symptoms)
                    {
                        if (b.Value == false)
                            break;
                    }
                    Debug.Log("I'm Cured!");
                    break;
                }
            }
        }
    }

    public void KillPatient()
    {
        m_occupied = false;
        Destroy(patientObject);
        m_bedPatient = null;
    }
}
