using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{

    private static BackgroundManager instance;
    public static BackgroundManager Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<BackgroundManager>();
            }
            return instance;
        }
    }

    [SerializeField] List<Sprite> currentImage;
    public Sprite currentSprite;
    private int currentSpriteIndex = 0;
    public int triggerCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        triggerCount = 0;

        currentSprite = currentImage[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerCount > 12)
        {
            triggerCount = 0;
            NextBackground();
            gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
        }
    }

    public void NextBackground()
    {
            currentSpriteIndex++;
            currentSprite = currentImage[currentSpriteIndex];
      
    }

}
