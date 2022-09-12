using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    public GameObject[] panels;

    // Start is called before the first frame update
    public void DisplayPanel(int index)
    {
        for (int i = 0; i < panels.GetLength(0); i++)
        {
            if (i != index) panels[i].SetActive(false);
            else panels[i].SetActive(true);
        }
    }
}