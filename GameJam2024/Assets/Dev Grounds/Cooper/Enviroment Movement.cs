using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovement : MonoBehaviour
{
    [Range(0f, 20f)]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float waitTime;

    public bool canMove;

    private void Start()
    {
        canMove = false;
        StartCoroutine(WaitToMove());
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
            transform.position += new Vector3(-1 * moveSpeed * Time.deltaTime, 0, 0);
            
    }

    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(waitTime);

        canMove = true;
    }
}
