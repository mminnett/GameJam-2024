using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextBoxes : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    [SerializeField] public GameObject buttonCollider;
    Vector3 startPosition;
    Vector3 endPosition;
    [SerializeField] float waitTimer = 4;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
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
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(WaitTime());
        // Debug.Log("END DRAG");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("hello");
        if (collision.gameObject.tag == "GameZone")
        {
            Debug.Log("We got him");
        }
    }

    public void collided()
    {
        endPosition = startPosition;
        gameObject.SetActive(false);
        buttonCollider.SetActive(false);
    }

    public IEnumerator WaitTime()
    {

        yield return new WaitForSeconds(waitTimer);

        transform.position = startPosition;
    }
}
