using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    private Tab[] tabs;
    public GameObject[] panels;

    private int currentTab = 0;
    public int CurrentTab { get { return currentTab; } }

    // Start is called before the first frame update
    private void Start()
    {
        tabs = GetComponentsInChildren<Tab>();

        foreach (Tab tab in tabs)
            tab.OnClick += DisplayPanel;
    }

    private void DisplayPanel(Tab newTab)
    {
        panels[newTab.index].SetActive(true);
        for (int i = 0; i < tabs.GetLength(0); i++)
        {

        }
    }
}