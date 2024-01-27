using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedManager : MonoBehaviour
{
    //Making the bed manager a singleton
    public static BedManager instance {get; private set;}
    private void Awake()
    {
        if(instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    //Things to track
    List<Bed> beds = new List<Bed>();
    public List<GameObject> patientPrefabs = new List<GameObject>();
    public List<Sprite> diseaseIcons = new List<Sprite>();

    //Setting up diseases
    private List<Disease> diseases = new List<Disease>();


    // Start is called before the first frame update
    void Start() {
        diseases.Add(new Disease("Disease 1", new Disease.Symptoms[] { Disease.Symptoms.Blindness, Disease.Symptoms.Sniffles }, diseaseIcons[0]));
        diseases.Add(new Disease("Disease 2", new Disease.Symptoms[] { Disease.Symptoms.Cough, Disease.Symptoms.Sniffles }, diseaseIcons[1]));
        diseases.Add(new Disease("Disease 3", new Disease.Symptoms[] { Disease.Symptoms.Dehydraded, Disease.Symptoms.Cough }, diseaseIcons[2]));
        diseases.Add(new Disease("Disease 4", new Disease.Symptoms[] { Disease.Symptoms.Dehydraded, Disease.Symptoms.Blindness }, diseaseIcons[3]));
    }

    // Update is called once per frame
    void Update()
    {
        //check beds, if empty invoke (fill bed)
        foreach(Bed b in beds)
        {
            if(!b.Occupied)
            {
                FillBed(b);
            }
        }

    }


    IEnumerator FillBed(Bed bed)
    {
        bed.Occupied = true;
        yield return new WaitForSeconds(3);
        
        //generate person and add to bed
        bed.BedPatient = patientPrefabs[Random.Range(0, patientPrefabs.Count)].GetComponent<Patient>();
        //give person illness
        bed.BedPatient.Illness = diseases[Random.Range(0, diseases.Count)];
    }
}
