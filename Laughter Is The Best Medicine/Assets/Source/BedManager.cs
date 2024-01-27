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


    List<Bed> beds = new List<Bed>();


    //Setting up diseases
    private List<Disease> diseases = new List<Disease>();


    // Start is called before the first frame update
    void Start() {
        diseases.Add(new Disease("Disease 1", new Disease.Symptoms[] { Disease.Symptoms.Blindness, Disease.Symptoms.Sniffles }));
        diseases.Add(new Disease("Disease 2", new Disease.Symptoms[] { Disease.Symptoms.Cough, Disease.Symptoms.Sniffles }));
        diseases.Add(new Disease("Disease 3", new Disease.Symptoms[] { Disease.Symptoms.Dehydraded, Disease.Symptoms.Cough }));
        diseases.Add(new Disease("Disease 4", new Disease.Symptoms[] { Disease.Symptoms.Dehydraded, Disease.Symptoms.Blindness }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
