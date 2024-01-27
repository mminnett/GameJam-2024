using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextBoxes : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    [SerializeField] public GameObject button;
    Vector3 startPosition;
    Vector3 endPosition;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDED");
        if (itemBeingDragged == null && endPosition != Vector3.one) 
        {
            //if statment for if the word on the button matchs the word needed
            endPosition = Vector3.one;
            button.SetActive(false);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        endPosition = transform.position;
        transform.position = startPosition;
        Debug.Log("END DRAG");
    }
}
