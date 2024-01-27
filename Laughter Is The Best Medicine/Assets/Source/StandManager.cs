using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandManager : MonoBehaviour
{
    bool isTouched;
    public void Interaction()
    {
        if (!isTouched)
        {
            isTouched = true;
            Debug.Log("Touched the Butt");
        }
    }
}
