using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public LevelLoad loadGame;

   private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonStart = root.Q<Button>("Start_Button");
        // Button buttonSetting = root.Q<Button>("Settings_Button");
        Button buttonExit = root.Q<Button>("Exit_Button");

        buttonStart.clicked += () => loadGame.LoadLevel();
        // buttonSetting.clicked += () =>
        buttonExit.clicked += () => Application.Quit();
    }
}
