using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{
    [SerializeField] 
    private GameObject dialogue;
    [SerializeField] 
    private GameObject button;
    //TextMeshProUGUI
    private void Start()
    {
        button.SetActive(false);
    }

    private void OnEnable()
    {     
        StartGame.beginGame += TurnOnButton;
    }

    private void OnDisable()
    {
        StartGame.beginGame -= TurnOnButton;
    }

    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
    }

    public void TurnOnButton()
    {
        button.SetActive(true);
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
