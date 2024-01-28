using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> painClips;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(painClips[Random.Range(0, painClips.Count)]);
        }
    }
}
