using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    private static ButtonManager instance;
    public static ButtonManager Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<ButtonManager>();
            }
            return instance;
        }
    }

    [SerializeField] public List<GameObject> buttons;

    [SerializeField] public GameObject speachBox;
    [SerializeField] public GameObject speachBoxPoint;
    [SerializeField] public GameObject promptText;
    [SerializeField] public GameObject enviornmentManager;
    [SerializeField] public float speedUpLength;
    public bool hasCollided;
    public string theButtonText;
    public List<string> theAnswers;
    public bool enemyIsDead;
    public GameObject activeEnemy;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        enemyIsDead = false;
        hasCollided = false;

        speachBox.gameObject.SetActive(false);
        speachBoxPoint.gameObject.SetActive(false);
        promptText.gameObject.SetActive(false);
    }
}
