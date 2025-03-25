using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Action : MonoBehaviour
{

    private static Action instance;
    public static Action Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<Action>();
            }
            return instance;
        }
    }

    public int startpoint;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        startpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonManager.Instance.hasCollided)
        {
            if (checkButtonPun(ButtonManager.Instance.theAnswers, ButtonManager.Instance.theButtonText)) 
            {
                Debug.Log("YEEEEEEEEEEEEEEEEEEEEEEEESSSSSSSSSSSSSSSSSSSSSSSSS");
                Debug.Log("startpoint " + startpoint);
            }
        }
    }

    public bool checkButtonPun(List<string> enemyText, string buttonText) 
    {
        if (enemyText.Count >= 0)
        {
            if (enemyText[startpoint] == buttonText)
            {
                foreach (GameObject butt in ButtonManager.Instance.buttons)
                {
                    Debug.Log("Looping through butts");
                    if (butt.gameObject.GetComponentInChildren<TextMeshProUGUI>() != null)
                    {
                        Debug.Log("Child has text component");
                        if (butt.gameObject.GetComponentInChildren<TextMeshProUGUI>().text == buttonText)
                        {
                            Debug.Log("Text matches correct answer");
                            butt.GetComponent<TextBoxes>().StartWaitTimer(true);
                        }
                    }
                }

                startpoint++;
                if (startpoint >= enemyText.Count)
                {
                    Debug.Log("They almost there");
                    startpoint = 0;
                    ButtonManager.Instance.enemyIsDead = true;
                }
                return true;
            }
        }
        return false;
    }
}
