using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClownArmMove : MonoBehaviour
{
    [SerializeField]
    private Transform targetPos;

    private void OnEnable()
    {
        StartCoroutine(Lerp(this.gameObject, targetPos.position));
    }

    IEnumerator Lerp(GameObject targetObject, Vector2 endPos)
    {
        float elapsedTime = 0;
        float lerpDur = 2.0f;

        Vector2 startPos = targetObject.transform.position;

        while (elapsedTime < lerpDur)
        {
            targetObject.transform.position = Vector2.Lerp(startPos, endPos, elapsedTime / lerpDur);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        targetObject.transform.position = endPos;

        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(0);
    }
}
