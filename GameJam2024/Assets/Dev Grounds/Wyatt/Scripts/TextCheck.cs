using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Yay it worked");
        if (collision.gameObject.tag == "Button")
        {
            //if statment for if the word on the button matchs the word needed
            collision.gameObject.GetComponent<ButtonCollider>().whatButton.GetComponent<TextBoxes>().collided();
            collision.gameObject.GetComponent<ButtonCollider>().collided();
        }
    }
}
