using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeStateSwitcher
{
    private BeeState currentState;
    public BeeState CurrentBeeState { get { return currentState; } set { currentState = value; } }

    public BeeStateSwitcher(BeeState newState)
    {
        currentState = newState;
    }
}