using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private TextMeshProUGUI textHolder;
        public ActionBasedController actionBasedController;

        [Header("Text Options")]
        [SerializeField, TextArea] private string input;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        //[Header("Character Image")]
        //[SerializeField] private Sprite characterSprite;
        //[SerializeField] private Image imageHolder;

        private Coroutine lineAppear;
        private XRIDefaultInputActions inputActions;

        private void Awake()
        {
            //imageHolder.sprite = characterSprite;
            //imageHolder.preserveAspect = true;
            inputActions = new XRIDefaultInputActions();
        }

        private void OnEnable() => inputActions.Enable();

        private void OnDisable() => inputActions.Disable();

        private void Start()
        {
            ResetLine();
            lineAppear = StartCoroutine(WriteText(input, textHolder, delay, sound, delayBetweenLines));
        }

        private void Update()
        {
            if (inputActions.XRIRightHandInteraction.UIPress.triggered)
            {
                if (textHolder.text != input)
                {
                    if (lineAppear != null)
                    {
                        StopCoroutine(lineAppear);
                    }

                    textHolder.text = input;
                }
                else
                    finished = true;
            }
        }

        private void Line()
        {
            if (textHolder.text != input)
            {
                if (lineAppear != null)
                {
                    StopCoroutine(lineAppear);
                }

                textHolder.text = input;
            }
            else
                finished = true;
        }

        private void ResetLine()
        {
            textHolder = GetComponent<TextMeshProUGUI>();
            textHolder.text = "";
            finished = false;
        }
    }
}
