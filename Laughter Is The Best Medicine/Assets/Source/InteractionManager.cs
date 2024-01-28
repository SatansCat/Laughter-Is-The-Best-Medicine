using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionManager : MonoBehaviour
{
    //public variables for interaction logic
    public bool isInRange;
    //interactKey set to E in Unity inspector
    public KeyCode interactKey;
    public UnityEvent interactAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If we are in range of an object
        if (isInRange)
        {
            //And if the player has pushed the interact key
            if (Input.GetKeyDown(interactKey))
            {
                //fire event
                interactAction.Invoke();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player out of range");
        }
    }
}
