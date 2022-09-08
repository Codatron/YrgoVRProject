using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject[] panels;
    public TabController tabs;

    private void DisplayPanel()
    {
        panels[tabs.CurrentTab].SetActive(true);
    }
}