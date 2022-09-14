using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{
    [SerializeField] 
    private GameObject dialogue;
    [SerializeField] 
    private GameObject button;
    //TextMeshProUGUI


    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
    }

    public void TurnOffButton()
    {
        button.SetActive(false);
    }

    //public bool DialogueActive()
    //{
    //    return dialogue.activeInHierarchy;
    //}
}
