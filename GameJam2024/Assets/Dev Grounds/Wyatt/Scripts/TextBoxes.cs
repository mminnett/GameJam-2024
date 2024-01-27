using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextBoxes : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    [SerializeField] public GameObject buttonCollider;
    private Collider2D _collider;
    Vector3 startPosition;
    Vector3 endPosition;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
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
        buttonCollider.transform.position = endPosition;
       transform.position = startPosition;
       // Debug.Log("END DRAG");
    }

    public void collided()
    {
        endPosition = startPosition;
        gameObject.SetActive(false);
       // buttonCollider.SetActive(false);
    }
}
