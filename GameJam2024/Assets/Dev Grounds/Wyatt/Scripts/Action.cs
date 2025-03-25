using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    public Enemy whatEnemy;

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
                if (startpoint == 1)
                {
                    ButtonManager.Instance.promptText.GetComponent<TextMeshProUGUI>().text = whatEnemy.setup2;
                }
                else if (startpoint == 2)
                {
                    ButtonManager.Instance.promptText.GetComponent<TextMeshProUGUI>().text = whatEnemy.setup3;
                }
                else if (startpoint == 3)
                {
                    ButtonManager.Instance.promptText.GetComponent<TextMeshProUGUI>().text = whatEnemy.setup4;
                }
                else if (startpoint == 4)
                {
                    ButtonManager.Instance.promptText.GetComponent<TextMeshProUGUI>().text = whatEnemy.setup5;
                }
                else if (startpoint == 5)
                {
                    ButtonManager.Instance.promptText.GetComponent<TextMeshProUGUI>().text = whatEnemy.setup6;
                }

                if (startpoint >= enemyText.Count)
                {
                    Debug.Log("They almost there");
                    startpoint = 0;
                    ButtonManager.Instance.enemyIsDead = true;
                    ButtonManager.Instance.speachBox.SetActive(false);
                    ButtonManager.Instance.speachBoxPoint.SetActive(false);
                    ButtonManager.Instance.promptText.SetActive(false);
                    ButtonManager.Instance.enviornmentManager.GetComponent<EnviromentMovement>().moveSpeed = 7.8f;
                }
                return true;
            }
        }
        return false;
    }
}
