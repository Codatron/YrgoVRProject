using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IfHighlight : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private GameObject yellowImage;

    private void Start()
    {
        yellowImage.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        yellowImage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        yellowImage.SetActive(false);
    }

    private void OnDisable()
    {
        yellowImage.SetActive(false);
    }


}
