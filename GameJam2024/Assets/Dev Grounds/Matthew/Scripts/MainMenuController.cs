/*
 * Author: Matthew Minnett
 * Date: 1/28/2024
 * Desc: Controls main menu functions (loading game/quitting game)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    [SerializeField, Tooltip("Title")]
    private GameObject title;

    [Header("Interactable Elements")]
    [SerializeField, Tooltip("Button for starting the game")]
    private GameObject startBtn;
    [SerializeField, Tooltip("Button for qutting the game")]
    private GameObject quitBtn;

    [Header("Position Data")]
    [SerializeField, Tooltip("End position to move start button to")]
    private Transform endPosStart;

    [SerializeField, Tooltip("End position to move quit button to")]
    private Transform endPosQuit;

    private void Start()
    {
        title.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0);

        StartCoroutine(WaitForAnimation());
        StartCoroutine(FadeTitle());
    }

    private IEnumerator FadeTitle()
    {
        yield return new WaitForSeconds(1f);

        while(title.GetComponent<UnityEngine.UI.Image>().color.a != 1)
        {
            title.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, title.GetComponent<UnityEngine.UI.Image>().color.a + 0.1f);

            yield return new WaitForSeconds(0.1f);
        }
    }

    /// <summary>
    /// Waits for opening animation to finish
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(1.5f);

        StartCoroutine(MoveButton(startBtn, endPosStart.position));
        StartCoroutine(MoveButton(quitBtn, endPosQuit.position));
    }

    /// <summary>
    /// Linearly interpolates from a starting position to an end position (moves object to a position)
    /// </summary>
    /// <param name="button">Object to move</param>
    /// <param name="endPos">Position to move to</param>
    /// <returns></returns>
    private IEnumerator MoveButton(GameObject button, Vector2 endPos)
    {
        float timeElapsed = 0;
        float lerpDuration = 3f;
        while(timeElapsed < lerpDuration)
        {
            button.transform.position = Vector2.Lerp(button.transform.position, endPos, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        button.transform.position = endPos;
    }

    /// <summary>
    /// Loads game scene
    /// </summary>
    public void StartButton()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Simply quits application
    /// </summary>
    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // for closing if in unity editor
#else
        Application.Quit();
#endif
    }
}
