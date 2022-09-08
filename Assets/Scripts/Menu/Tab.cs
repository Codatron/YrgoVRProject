using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    public delegate void HandleInteraction(Tab tab);
    public event HandleInteraction OnClick;

    public TabStates CurrentState { get => currentState;}
    private TabStates currentState;

    private Image myImage;

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        currentState = TabStates.Active;
    }

    private void Update()
    {
        switch (currentState)
        {
            case TabStates.Active:
                ChangeColor(5);
                break;
            case TabStates.Inactive:
                //ToDo: turn of object
                break;
            case TabStates.Clicked:
                ChangeColor(4);
                break;
            case TabStates.MouseOver:
                ChangeColor(2);
                break;
            default:
                break;
        }
    }

    private void OnMouseDown()
    {
        currentState = TabStates.Clicked;
        OnClick?.Invoke(this);
    }

    private void OnMouseExit()
    {
        currentState = TabStates.Active;
    }

    private void OnMouseOver()
    {
        currentState = TabStates.MouseOver;
    }

    private void ChangeColor(int index)
    {
        myImage.color = ColorPalette.Instance.palette.colors[index];
    }
}