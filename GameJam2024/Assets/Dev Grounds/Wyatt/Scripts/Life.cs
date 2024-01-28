using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{

    [SerializeField] List<Image> lives;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Image life in lives) 
        { 
        life.enabled = true; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lives.Count <= 0) 
        { 
            //Activate end game
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            int amtLeft = -1;
            foreach (Image life in lives)
            {
                amtLeft++;
            }

            Debug.Log("Och");
            lives.Remove(lives[amtLeft]);
        }
    }
}
