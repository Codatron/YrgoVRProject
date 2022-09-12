using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseRayCast : MonoBehaviour
{
    PointerEventData pointerEventData;
    List<RaycastResult> raycastResults = new List<RaycastResult>();

    private void Awake()
    {
        pointerEventData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
    }

    private void Update()
    {
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        if (Input.GetMouseButtonDown(0))
        {
            foreach (RaycastResult result in raycastResults)
            {
                if (result.gameObject.CompareTag("Button"))
                {
                    result.gameObject.GetComponent<Button>().Clicked();
                }
            }
        }
    }
}