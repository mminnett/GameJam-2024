using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    
    public enum eventType {ENEMY, JUMP, SLIDE, START, FINISH}

    public eventType type;

    public bool isTriggered;

    private int whatEnemy;

    [SerializeField] private Transform enemySpawn;
    private List<GameObject> enemy1;
    private List<GameObject> enemy2;
    private List<GameObject> enemy3;
    private List<GameObject> enemy4;

    private GameObject parent;

    private void Awake()
    {
        parent = transform.parent.gameObject;

        enemy1 = EnemyManager.Instance.enemyList1;
        enemy2 = EnemyManager.Instance.enemyList2;
        enemy3 = EnemyManager.Instance.enemyList3;
        enemy4 = EnemyManager.Instance.enemyList4;
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (type)
        {
            case eventType.ENEMY:
                BackgroundManager.Instance.triggerCount++;
                Debug.Log("Enemy trigger");
                EnemyPick();
                break;

            case eventType.JUMP:
                BackgroundManager.Instance.triggerCount++;
                break;

            case eventType.SLIDE:
                BackgroundManager.Instance.triggerCount++;
                break;

            case eventType.START:

                break;

            case eventType.FINISH:
                
                break;
        }
    }

    private void EnemyPick()
    {
        if (parent.tag == "EnemyTerrain" && LevelManager.Instance.type == LevelManager.TerrainType.FOOD)
        {
            if (EnemyManager.Instance.enemyList1.Count > 0)
            {
                int i = Random.Range(0, enemy1.Count);
                whatEnemy = i;
                SetUpButtons();
                Debug.Log("Spawn 'Enemy'");
                Instantiate(EnemyManager.Instance.enemyList1[i], new Vector3(enemySpawn.position.x, enemySpawn.position.y + 1, enemySpawn.position.z), Quaternion.identity, parent.transform);
                EnemyManager.Instance.enemyList1.Remove(EnemyManager.Instance.enemyList1[i]);
            }
            else
            {
                LevelManager.Instance.type = LevelManager.TerrainType.MEDIEVAL;
            }
        }

        else if (parent.tag == "EnemyTerrain" && LevelManager.Instance.type == LevelManager.TerrainType.MEDIEVAL)
        {
            if (EnemyManager.Instance.enemyList2.Count > 0)
            {
                int i = Random.Range(0, enemy2.Count);
                whatEnemy = i;
                SetUpButtons();
                Debug.Log("Spawn 'Enemy'");
                Instantiate(EnemyManager.Instance.enemyList2[i], new Vector3(enemySpawn.position.x, enemySpawn.position.y + 1, enemySpawn.position.z), Quaternion.identity, parent.transform);
                EnemyManager.Instance.enemyList2.Remove(EnemyManager.Instance.enemyList2[i]);
            }
            else
            {
                LevelManager.Instance.type = LevelManager.TerrainType.MODERN;
            }
        }

        else if (parent.tag == "EnemyTerrain" && LevelManager.Instance.type == LevelManager.TerrainType.MODERN)
        {
            if (EnemyManager.Instance.enemyList3.Count > 0)
            {
                int i = Random.Range(0, enemy3.Count);
                whatEnemy = i;
                SetUpButtons();
                Debug.Log("Spawn 'Enemy'");
                Instantiate(EnemyManager.Instance.enemyList3[i], new Vector3(enemySpawn.position.x, enemySpawn.position.y + 1, enemySpawn.position.z), Quaternion.identity, parent.transform);
                EnemyManager.Instance.enemyList3.Remove(EnemyManager.Instance.enemyList3[i]);
            }
            else
            {
                LevelManager.Instance.type = LevelManager.TerrainType.SCIFI;
            }
        }

        else if (parent.tag == "EnemyTerrain" && LevelManager.Instance.type == LevelManager.TerrainType.SCIFI)
        {
            if (EnemyManager.Instance.enemyList4.Count > 0)
            {
                int i = Random.Range(0, enemy4.Count);
                whatEnemy = i;
                SetUpButtons();
                Debug.Log("Spawn 'Enemy'");
                Instantiate(EnemyManager.Instance.enemyList4[i], new Vector3(enemySpawn.position.x, enemySpawn.position.y + 1, enemySpawn.position.z), Quaternion.identity, parent.transform);
                EnemyManager.Instance.enemyList4.Remove(EnemyManager.Instance.enemyList4[i]);
            }
        }
    }

    private void SetUpButtons()
    {
        ButtonManager.Instance.speachBox.SetActive(true);
        ButtonManager.Instance.speachBoxPoint.SetActive(true);
        ButtonManager.Instance.promptText.SetActive(true);

        if (LevelManager.Instance.type == LevelManager.TerrainType.FOOD)
        {
            Debug.Log(whatEnemy);
            foreach (string buttonText in EnemyManager.Instance.enemyList1[whatEnemy].GetComponent<Enemy>().answer)
            {
                ButtonManager.Instance.promptText.GetComponent<TextMeshProUGUI>().text = EnemyManager.Instance.enemyList1[whatEnemy].GetComponent<Enemy>().setup;

                int i = Random.Range(0, ButtonManager.Instance.buttons.Count);

                while (ButtonManager.Instance.buttons[i].gameObject.activeSelf)
                {
                    i = Random.Range(0, ButtonManager.Instance.buttons.Count);
                }

                ButtonManager.Instance.buttons[i].gameObject.SetActive(true);
                ButtonManager.Instance.buttons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
            }
        }

        else if (LevelManager.Instance.type == LevelManager.TerrainType.MEDIEVAL)
        {
            Debug.Log(whatEnemy);
            foreach (string buttonText in EnemyManager.Instance.enemyList2[whatEnemy].GetComponent<Enemy>().answer)
            {
                ButtonManager.Instance.promptText.GetComponent<TextMeshProUGUI>().text = EnemyManager.Instance.enemyList2[whatEnemy].GetComponent<Enemy>().setup;

                int i = Random.Range(0, ButtonManager.Instance.buttons.Count);

                while (ButtonManager.Instance.buttons[i].gameObject.activeSelf)
                {
                    i = Random.Range(0, ButtonManager.Instance.buttons.Count);
                }

                ButtonManager.Instance.buttons[i].gameObject.SetActive(true);
                ButtonManager.Instance.buttons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
            }
        }

        else if (LevelManager.Instance.type == LevelManager.TerrainType.MODERN)
        {
            Debug.Log(whatEnemy);
            foreach (string buttonText in EnemyManager.Instance.enemyList3[whatEnemy].GetComponent<Enemy>().answer)
            {
                ButtonManager.Instance.promptText.GetComponent<TextMeshProUGUI>().text = EnemyManager.Instance.enemyList3[whatEnemy].GetComponent<Enemy>().setup;

                int i = Random.Range(0, ButtonManager.Instance.buttons.Count);

                while (ButtonManager.Instance.buttons[i].gameObject.activeSelf)
                {
                    i = Random.Range(0, ButtonManager.Instance.buttons.Count);
                }

                ButtonManager.Instance.buttons[i].gameObject.SetActive(true);
                ButtonManager.Instance.buttons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
            }
        }

        else if (LevelManager.Instance.type == LevelManager.TerrainType.SCIFI)
        {
            Debug.Log(whatEnemy);
            foreach (string buttonText in EnemyManager.Instance.enemyList4[whatEnemy].GetComponent<Enemy>().answer)
            {
                ButtonManager.Instance.promptText.GetComponent<TextMeshProUGUI>().text = EnemyManager.Instance.enemyList4[whatEnemy].GetComponent<Enemy>().setup;

                int i = Random.Range(0, ButtonManager.Instance.buttons.Count);

                while (ButtonManager.Instance.buttons[i].gameObject.activeSelf)
                {
                    i = Random.Range(0, ButtonManager.Instance.buttons.Count);
                }

                ButtonManager.Instance.buttons[i].gameObject.SetActive(true);
                ButtonManager.Instance.buttons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
            }
        }
    }
}
