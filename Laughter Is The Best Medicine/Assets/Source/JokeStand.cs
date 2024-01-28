using UnityEngine;

public class JokeStand : MonoBehaviour
{
    //private GameObject player;
    public StandManager.JokeType jokeType;
    private string[] setups;
    private string[] punchlines;
    int randNum;

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
        randNum = Random.Range(0, 99);
        Debug.Log(setups[randNum] + punchlines[randNum]);
        //player = GameObject.FindWithTag("Player");
    }

    public void Interaction()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().HasJoke == false)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().HasJoke = true;
            randNum = Random.Range(0, 99);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().TheJoke = setups[randNum] + punchlines[randNum];
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().HeldJokeType = jokeType;
        }
        else
        {
            Debug.Log("Holding joke already");
        }
    }
}
