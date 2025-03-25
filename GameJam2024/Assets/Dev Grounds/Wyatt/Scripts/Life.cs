using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    private int amtLeft = 0;

    [SerializeField] List<Image> lives;
    SpriteRenderer playerColour;

    [SerializeField] private float hitTimer;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> painClips;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Image life in lives)
        {
            life.gameObject.SetActive(true);
            playerColour = GetComponent<SpriteRenderer>();
            amtLeft++;
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
            amtLeft -= 1;


            foreach (GameObject button in ButtonManager.Instance.buttons)
            {
                if (button.activeSelf == true)
                {
                    button.GetComponent<TextBoxes>().StartWaitTimer(true);
                }
            }

            ButtonManager.Instance.speachBox.SetActive(false);
            ButtonManager.Instance.speachBoxPoint.SetActive(false);
            ButtonManager.Instance.promptText.SetActive(false);

            Debug.Log("Och");
            lives[amtLeft].gameObject.SetActive(false);
            StartCoroutine(Flash());

            ButtonManager.Instance.enviornmentManager.GetComponent<EnviromentMovement>().moveSpeed = 7.8f;

            audioSource.PlayOneShot(painClips[Random.Range(0, painClips.Count)]);

            //lives.Remove(lives[amtLeft]);

            collision.gameObject.SetActive(false);
        }
    }

    IEnumerator Flash()
    {
        playerColour.color = Color.red;

        yield return new WaitForSeconds(hitTimer);

        playerColour.color = Color.white;
    }
}
