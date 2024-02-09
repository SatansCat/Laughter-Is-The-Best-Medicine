using UnityEngine;
using UnityEngine.UIElements;

public class Clipboard : MonoBehaviour
{
    private Patient m_bedPatient;

    public UIDocument clipboardUI;
    public Label symptomLabel;


    public Patient BedPatient
    {
        get { return m_bedPatient; }
        set { m_bedPatient = value; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You left the patient's side :'(");

            CloseClipboard();
        }
    }

    public void OpenClipboard()
    {
        Debug.Log("Yup, Q definately pressed");

        clipboardUI.enabled = !clipboardUI.enabled;

        symptomLabel.text = m_bedPatient.Illness.symptoms.ToString();
    }

    public void CloseClipboard()
    {
        clipboardUI.enabled = false;
    }
}
