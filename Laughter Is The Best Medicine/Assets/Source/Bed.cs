using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
