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

    public ButtonManager btnManager;
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

        //textObject.text = setup;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
