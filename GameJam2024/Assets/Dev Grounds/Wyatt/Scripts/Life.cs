using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{

    [SerializeField] List<Image> lives;
    SpriteRenderer playerColour;

    [SerializeField] private float hitTimer;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Image life in lives)
        {
            life.gameObject.SetActive(true);
            playerColour = GetComponent<SpriteRenderer>();
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

            foreach (GameObject button in ButtonManager.Instance.buttons)
            {
                button.gameObject.SetActive(false);
            }

            ButtonManager.Instance.speachBox.SetActive(false);
            ButtonManager.Instance.speachBoxPoint.SetActive(false);
            ButtonManager.Instance.promptText.SetActive(false);

            Debug.Log("Och");
            lives[amtLeft].gameObject.SetActive(false);
            StartCoroutine(Flash());
            lives.Remove(lives[amtLeft]);
        }
    }

    IEnumerator Flash()
    {
        playerColour.color = Color.red;

        yield return new WaitForSeconds(hitTimer);

        playerColour.color = Color.white;
    }
}
