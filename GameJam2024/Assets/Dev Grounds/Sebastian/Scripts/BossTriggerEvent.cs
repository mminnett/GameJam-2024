using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTriggerEvent : MonoBehaviour
{
    public bool isTriggered;
    [SerializeField] private GameObject bossObject;
    [SerializeField] private Transform playerEndPos;

    [SerializeField] private Transform bossEndPos;

    private EnviromentMovement check;
    private GameObject parent;
    private GameObject player;

    private Animator clownBorder;
    private Animator clownBoss;

    void Start()
    {
        parent = transform.parent.gameObject;

        check = FindObjectOfType<EnviromentMovement>();

        clownBorder = GameObject.FindGameObjectWithTag("Frame").GetComponent<Animator>();
        clownBoss = GameObject.FindGameObjectWithTag("ClownBoss").GetComponent <Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            clownBorder.SetTrigger("BossTrigger");

            StartCoroutine(WaitToInstantiate());

            if (check != null)
            {
                check.canMove = false;
            }

            player = other.gameObject;
            StartCoroutine(Lurp(player, playerEndPos.position));
        }
    }

    private void Update()
    {
        if (check == null)
        {
            check = FindObjectOfType<EnviromentMovement>();
        }
    }

    private IEnumerator WaitToInstantiate()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine(Lurp(bossObject, bossEndPos.position));
    }

    IEnumerator Lurp(GameObject targetObject, Vector2 endPos)
    {
        float elpasedTime = 0;
        float lerpDur = 2.0f;

        Vector2 startPos = targetObject.transform.position;

        while (elpasedTime < lerpDur)
        {
            targetObject.transform.position = Vector2.Lerp(startPos, endPos, elpasedTime / lerpDur);
            elpasedTime += Time.deltaTime;
            yield return null;
        }
        targetObject.transform.position = endPos;

        if(targetObject == player)
            targetObject.gameObject.GetComponent<Animator>().SetTrigger("StopRun");
        else if(targetObject == bossObject)
            clownBoss.SetTrigger("ClownTime");
    }
}
