using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Game : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
