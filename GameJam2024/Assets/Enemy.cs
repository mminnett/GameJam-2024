using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private static Enemy instance;

    public static Enemy Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<Enemy>();
            }
            return instance;
        }
    }

    [SerializeField] private TriggerEvent triggerEvent;
    [SerializeField] private TextMeshPro textObject;
    [SerializeField] private GameObject setupText;

    [SerializeField] private int enemyId;

    [SerializeField] public string setup;
    [SerializeField] public List<string> answer;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

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
