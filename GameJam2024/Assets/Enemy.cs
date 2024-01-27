using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TriggerEvent triggerEvent;
    [SerializeField] private TextMeshPro textObject;
    [SerializeField] private GameObject setupText;

    [SerializeField] private int enemyId;

    [SerializeField] private string setup;
    [SerializeField] private string answer;
    private void Start()
    {
        textObject.text = setup;
    }

    private void Update()
    {
        if (triggerEvent.isTriggered == true && triggerEvent.type == TriggerEvent.eventType.ENEMY)
        {
            if(setup != "")
            {
                setupText.SetActive(true);
            }
            else
            {
                setupText.SetActive(false);
            }
        }
    }
}
