using System.Collections;
using System.Collections.Generic;
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

    private int startpoint;

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

        if (enemyText[startpoint] == buttonText)
            {
                startpoint++;
                if (startpoint == enemyText.Count)
                {
                Debug.Log("They almost there");
                    startpoint = 0;
                    ButtonManager.Instance.enemyIsDead = true;
                }
                return true;
            }
       return false;
    }
}
