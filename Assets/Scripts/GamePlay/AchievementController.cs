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

    public void DisplayMessage(int threshold, int index, float displayTime = 3)
    {
        TextMeshProUGUI tmpText = Instantiate(achievementText, canvas.transform);
        tmpText.text = nectarAchievements[index].Message + threshold;
        Destroy(tmpText, displayTime);
    }
}