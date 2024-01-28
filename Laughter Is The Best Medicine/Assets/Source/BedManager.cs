using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedManager : MonoBehaviour
{
    //Making the bed manager a singleton
    public static BedManager instance { get; private set; }
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

    //Things to track
    List<Bed> beds = new List<Bed>();
    public List<GameObject> patientPrefabs = new List<GameObject>();
    public List<Sprite> diseaseIcons = new List<Sprite>();


    //Setting up diseases
    private List<Disease> diseases = new List<Disease>();
    public Dictionary<Disease.Symptoms, StandManager.JokeType> cures = new Dictionary<Disease.Symptoms, StandManager.JokeType>();


    // Start is called before the first frame update
    void Start()
    {
        //Create diseases
        diseases.Add(new Disease("Disease 1", new Disease.Symptoms[] { Disease.Symptoms.Blindness }, diseaseIcons[0]));
        diseases.Add(new Disease("Disease 2", new Disease.Symptoms[] { Disease.Symptoms.Cough }, diseaseIcons[1]));
        diseases.Add(new Disease("Disease 3", new Disease.Symptoms[] { Disease.Symptoms.Dehydrated }, diseaseIcons[2]));
        diseases.Add(new Disease("Disease 4", new Disease.Symptoms[] { Disease.Symptoms.Sniffles }, diseaseIcons[3]));

        //Assign cures
        cures.Add(Disease.Symptoms.Cough, StandManager.JokeType.DadJokes);
        cures.Add(Disease.Symptoms.Dehydrated, StandManager.JokeType.AdultJokes);
        cures.Add(Disease.Symptoms.Blindness, StandManager.JokeType.PirateJokes);
        cures.Add(Disease.Symptoms.Sniffles, StandManager.JokeType.PunJokes);
    }

    // Update is called once per frame
    void Update()
    {
        //check beds, if empty invoke (fill bed)
        foreach (Bed b in beds)
        {
            if (!b.Occupied)
            {
                IEnumerator c = FillBed(b);
                StartCoroutine(c);
            }
        }
    }


    IEnumerator FillBed(Bed bed)
    {
        bed.Occupied = true;
        Debug.Log("[Enda] Bed fill "+bed.Occupied);
        yield return new WaitForSeconds(3);

        //generate person and add to bed
        bed.patientObject = Instantiate(patientPrefabs[Random.Range(0, patientPrefabs.Count)],bed.patientPosition.transform);
        bed.BedPatient = bed.patientObject.GetComponent<Patient>();
        bed.timer.value = 100;
        //give person illness
        bed.BedPatient.Illness = diseases[Random.Range(0, diseases.Count)];
        Debug.Log("illness: " + bed.BedPatient.Illness.symptoms.Keys.Count);
    }

    public void RegisterBed(Bed newBed)
    {
        beds.Add(newBed);
        //Debug.Log("[Enda] BED REGISTERED!!");
    }
}
