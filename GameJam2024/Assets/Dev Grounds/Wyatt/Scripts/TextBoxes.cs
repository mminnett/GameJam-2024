using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextBoxes : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    [SerializeField] public GameObject buttonCollider;
    public Vector3 startPosition;
    Vector3 endPosition;
    [SerializeField] float waitTimer = 0.02f;

    public void Start()
    {
        gameObject.SetActive(false);

        startPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        //startPosition = transform.position;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        //endPosition = transform.position;
        //buttonCollider.transform.position = endPosition;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(WaitTime());
        // Debug.Log("END DRAG");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "GameZone")
        {
            Debug.Log("Button is in the right place");
            ButtonManager.Instance.hasCollided = true;
            ButtonManager.Instance.theButtonText = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        }
    }

    /*
    public void collided()
    {
        endPosition = startPosition;
        gameObject.SetActive(false);
    }
    */

    public void StartWaitTimer(bool correct)
    {
        if(correct)
            StartCoroutine(DisableWaitTime());
        else
            StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {

        yield return new WaitForSeconds(waitTimer);

        transform.position = startPosition;
    }

    IEnumerator DisableWaitTime()
    {
        yield return new WaitForSeconds(waitTimer);

        transform.position = startPosition;
        gameObject.SetActive(false);
    }
}
