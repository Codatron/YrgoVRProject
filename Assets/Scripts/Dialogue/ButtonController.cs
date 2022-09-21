using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonController : MonoBehaviour
{
    [SerializeField] 
    private GameObject dialogue;
    [SerializeField] 
    private GameObject button;

    // ToDo:
    // Turn off upward thrust during dialogues/in beehive/etc;
    // How? Add new GameState? bool? 
    // Or...use primary button instead of tirgger button

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
