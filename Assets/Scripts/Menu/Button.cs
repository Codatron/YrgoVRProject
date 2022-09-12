using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public delegate void OnClickHandler();
    public event OnClickHandler OnClick;

    public void Clicked()
    {
        Debug.Log(name + " was Clicked");
        OnClick?.Invoke();
    }
}