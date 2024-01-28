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

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        speachBox.gameObject.SetActive(false);
        speachBoxPoint.gameObject.SetActive(false);
        promptText.gameObject.SetActive(false);
    }
}
