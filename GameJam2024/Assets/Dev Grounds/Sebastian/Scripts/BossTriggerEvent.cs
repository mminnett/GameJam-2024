using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTriggerEvent : MonoBehaviour
{
    public bool isTriggered;
    [SerializeField] private Transform BossSpawn;
    [SerializeField] private GameObject BossPrefab;
    [SerializeField] private Transform playerEndPos;
    private EnviromentMovement check;
    private GameObject parent;
    private GameObject player;

    void Start()
    {
        parent = transform.parent.gameObject;

        check = FindObjectOfType<EnviromentMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(BossPrefab, new Vector3(BossSpawn.position.x, BossSpawn.position.y + 1, BossSpawn.position.z), Quaternion.identity, parent.transform);
        if (check != null)
        {
            check.canMove = false;
        }

        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            StartCoroutine(PlayerLurp(player, playerEndPos.position));
        }
    }

    private void Update()
    {
        if (check == null)
        {
            check = FindObjectOfType<EnviromentMovement>();
        }
    }

    IEnumerator PlayerLurp(GameObject player, Vector2 endPos)
    {
        float elpasedTime = 0;
        float lerpDur = 4.0f;
        while (elpasedTime < lerpDur)
        {
            player.transform.position = Vector2.Lerp(player.transform.position, endPos, elpasedTime / lerpDur);
            elpasedTime += Time.deltaTime;
            yield return null;
        }
        player.transform.position = endPos;
    }

}
