using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Palette")]
public class UIColors : ScriptableObject
{
    [Header("UI")]
    public Color[] colors;
}