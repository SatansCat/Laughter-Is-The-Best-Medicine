using UnityEngine;
using UnityEngine.UIElements;

public class Pause_Menu : MonoBehaviour
{
    private UIDocument pauseUI;
    private bool gamePaused = false;


    void Start()
    {
        pauseUI = GetComponent<UIDocument>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Escape key was pressed");

            pauseUI.enabled = !pauseUI.enabled;

            gamePaused = !gamePaused;
        }

        Pause();
    }

    void Pause()
    {
        if (gamePaused == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
