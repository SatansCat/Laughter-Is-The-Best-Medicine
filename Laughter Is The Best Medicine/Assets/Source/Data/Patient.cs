using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    public enum PerfectJoke { }//ADD PERFECT JOKE TYPES ONCE JOKES DECIDED

    [SerializeField] private PerfectJoke m_faveJoke;
    [SerializeField] private GameObject m_person;
    [SerializeField] private Disease m_illness;

    public PerfectJoke FaveJoke
    {
        get { return m_faveJoke; }
        set { m_faveJoke = value; }
    }

    public GameObject Person
    {
        get { return m_person; }
        set { m_person = value; }
    }

    public Disease Illness
    {
        get { return m_illness; }
        set { m_illness = value; }
    }
}

public class Disease {
    public enum Symptoms { Cough, Sniffles, Dehydrated, Blindness};

    public string diseaseName; //Just adding this for easier tracking atm
    public Sprite Icon;
    //List<Symptoms> symptoms = new List<Symptoms>();
    public Dictionary<Symptoms, bool> symptoms = new Dictionary<Symptoms, bool>();

    public Disease(string diseaseName, Symptoms[] newSymptoms, Sprite Icon)
    {
        this.diseaseName = diseaseName;
        this.Icon = Icon;
        foreach (Symptoms s in newSymptoms)
        {
            symptoms.Add(s,false);
        }
    }
}
