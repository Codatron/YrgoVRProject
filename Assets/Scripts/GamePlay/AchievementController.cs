using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementController : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI achievementText;
    public AchievementMessages achievementmessages;

    public static AchievementController Instance { get { return instance; } }
    private static AchievementController instance;

    private Achievement[] nectarAchievements;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            CreateAchievements();
            GameManager.onRequirementMet += DisplayMessage;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateAchievements()
    {
        for (int i = 0; i < achievementmessages.nectarMessages.GetLength(0); i++)
            nectarAchievements[i] = new Achievement(achievementmessages.nectarMessages[i]);
    }

    private void DisplayMessage(int currentTotalNectar)
    {
        foreach (int index in achievementmessages.nectarThresholds)
        {
            if (currentTotalNectar == index)
            {
                TextMeshProUGUI tmpText = Instantiate(achievementText, canvas.transform);
                tmpText.text = achievementmessages.nectarMessages[0] + index;
            }
        }
    }
}