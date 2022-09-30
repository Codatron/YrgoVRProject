using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public string Message { get { return message; } }
    private string message;

    private int experienceGain;
    private float speedMultiplier;
    private bool isCompleted;

    public Achievement(string message = "", int experienceGain = 15, float speedMultiplier = 1.125f)
    {
        this.message = message;
        this.experienceGain = experienceGain;
        this.speedMultiplier = speedMultiplier;

        isCompleted = false;
    }

    public void Complete()
    {
        isCompleted = true;
    }
}