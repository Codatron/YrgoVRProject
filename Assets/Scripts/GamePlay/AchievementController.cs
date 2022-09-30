using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : MonoBehaviour
{
    public AchievementMessages messages;
    public static AchievementController Instance { get { return instance; } }
    private static AchievementController instance;

    private Achievement[] nectarAchievements;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            CreateAchievements();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateAchievements()
    {
        for (int i = 0; i < messages.nectarMessages.GetLength(0); i++)
            nectarAchievements[i] = new Achievement(messages.nectarMessages[i]);
    }

    public string DisplayMessage(int threshold, int index)
    {
        return nectarAchievements[index].Message + threshold;
    }
}