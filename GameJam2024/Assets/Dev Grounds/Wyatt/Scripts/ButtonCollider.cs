using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollider : MonoBehaviour
{
    [SerializeField] public GameObject whatButton;
    public Vector3 ogPosition;

    private void Awake()
    {
        ogPosition = transform.position;
    }

    public void collided()
    {
        transform.position = ogPosition;
    }
}
