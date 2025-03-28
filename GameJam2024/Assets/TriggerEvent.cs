using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{

    public enum eventType { ENEMY, JUMP, SLIDE, START, FINISH }

    public eventType type;

    public bool isTriggered;

    private int whatEnemy;

    float speed;

    [SerializeField] private Transform enemySpawn;
    private List<GameObject> enemy1;
    private List<GameObject> enemy2;
    private List<GameObject> enemy3;
    private List<GameObject> enemy4;

    private GameObject parent;

    private GameObject whoYouWantDead;

    private void Awake()
    {
        parent = transform.parent.gameObject;
        speed = 0;
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
        if (ButtonManager.Instance.enemyIsDead)
        {
            Debug.Log("They Be dead");
            if (ButtonManager.Instance.activeEnemy != null)
            {
                ButtonManager.Instance.activeEnemy.GetComponent<Enemy>().Kill();
            }
            StopAllCoroutines();
            ButtonManager.Instance.timer.value = 20;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (type)
        {
            case eventType.ENEMY:
                //ButtonManager.Instance.enemyIsDead = false;
                ButtonManager.Instance.theAnswers.Clear();
                ButtonManager.Instance.hasCollided = false;
                BackgroundManager.Instance.triggerCount++;
                Action.Instance.startpoint = 0;
                ButtonManager.Instance.timer.value = 20;
                ButtonManager.Instance.enemyIsDead = false;
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
                whoYouWantDead = EnemyManager.Instance.enemyList1[i];
                SetUpButtons();
                Debug.Log("Spawn 'Enemy'");
                ButtonManager.Instance.activeEnemy = Instantiate(EnemyManager.Instance.enemyList1[i], new Vector3(enemySpawn.position.x, enemySpawn.position.y + 1, enemySpawn.position.z), Quaternion.identity, parent.transform);
                ButtonManager.Instance.activeEnemy.gameObject.SetActive(true);
                ButtonManager.Instance.activeEnemy.GetComponent<Enemy>().btnManager = ButtonManager.Instance.GetComponent<ButtonManager>();
                EnemyManager.Instance.enemyList1.Remove(EnemyManager.Instance.enemyList1[i]);
                whoYouWantDead = ButtonManager.Instance.activeEnemy;
                Action.Instance.whatEnemy = whoYouWantDead.gameObject.GetComponent<Enemy>();
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
                whoYouWantDead = EnemyManager.Instance.enemyList2[i];
                SetUpButtons();
                Debug.Log("Spawn 'Enemy'");
                ButtonManager.Instance.activeEnemy = Instantiate(EnemyManager.Instance.enemyList2[i], new Vector3(enemySpawn.position.x, enemySpawn.position.y + 1, enemySpawn.position.z), Quaternion.identity, parent.transform);
                ButtonManager.Instance.activeEnemy.gameObject.SetActive(true);
                ButtonManager.Instance.activeEnemy.GetComponent<Enemy>().btnManager = ButtonManager.Instance.GetComponent<ButtonManager>();
                EnemyManager.Instance.enemyList2.Remove(EnemyManager.Instance.enemyList2[i]);
                whoYouWantDead = ButtonManager.Instance.activeEnemy;
                Action.Instance.whatEnemy = whoYouWantDead.gameObject.GetComponent<Enemy>();
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
                whoYouWantDead = EnemyManager.Instance.enemyList3[i];
                SetUpButtons();
                Debug.Log("Spawn 'Enemy'");
                ButtonManager.Instance.activeEnemy = Instantiate(EnemyManager.Instance.enemyList3[i], new Vector3(enemySpawn.position.x, enemySpawn.position.y + 1, enemySpawn.position.z), Quaternion.identity, parent.transform);
                ButtonManager.Instance.activeEnemy.gameObject.SetActive(true);
                ButtonManager.Instance.activeEnemy.GetComponent<Enemy>().btnManager = ButtonManager.Instance.GetComponent<ButtonManager>();
                EnemyManager.Instance.enemyList3.Remove(EnemyManager.Instance.enemyList3[i]);
                whoYouWantDead = ButtonManager.Instance.activeEnemy;
                Action.Instance.whatEnemy = whoYouWantDead.gameObject.GetComponent<Enemy>();
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
                whoYouWantDead = EnemyManager.Instance.enemyList4[i];
                SetUpButtons();
                Debug.Log("Spawn 'Enemy'");
                ButtonManager.Instance.activeEnemy = Instantiate(EnemyManager.Instance.enemyList4[i], new Vector3(enemySpawn.position.x, enemySpawn.position.y + 1, enemySpawn.position.z), Quaternion.identity, parent.transform);
                ButtonManager.Instance.activeEnemy.gameObject.SetActive(true);
                ButtonManager.Instance.activeEnemy.GetComponent<Enemy>().btnManager = ButtonManager.Instance.GetComponent<ButtonManager>();
                EnemyManager.Instance.enemyList4.Remove(EnemyManager.Instance.enemyList4[i]);
                whoYouWantDead = ButtonManager.Instance.activeEnemy;
                Action.Instance.whatEnemy = whoYouWantDead.gameObject.GetComponent<Enemy>();
            }
        }
    }

    private void SetUpButtons()
    {
        ButtonManager.Instance.speachBox.SetActive(true);
        ButtonManager.Instance.speachBoxPoint.SetActive(true);
        ButtonManager.Instance.promptText.SetActive(true);
        speed = FindAnyObjectByType<EnviromentMovement>().moveSpeed;
        StartCoroutine(SpeedAlt());

        if (LevelManager.Instance.type == LevelManager.TerrainType.FOOD)
        {
            Debug.Log(whatEnemy);
            foreach (string buttonText in EnemyManager.Instance.enemyList1[whatEnemy].GetComponent<Enemy>().answer)
            {
                ButtonManager.Instance.promptText.GetComponent<TextMeshProUGUI>().text = EnemyManager.Instance.enemyList1[whatEnemy].GetComponent<Enemy>().setup;

                ButtonManager.Instance.theAnswers.Add(buttonText);

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

                ButtonManager.Instance.theAnswers.Add(buttonText);

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

                ButtonManager.Instance.theAnswers.Add(buttonText);

                ButtonManager.Instance.theAnswers.Add(buttonText);

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

                ButtonManager.Instance.theAnswers.Add(buttonText);

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

    IEnumerator SpeedAlt()
    {
        Debug.Log("SpeedAlt");

        yield return new WaitForSeconds(ButtonManager.Instance.slowDownLength);

        ButtonManager.Instance.enviornmentManager.GetComponent<EnviromentMovement>().moveSpeed = 0;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (ButtonManager.Instance.timer.value > 0)
        {
            yield return new WaitForSeconds(0.2f);
            ButtonManager.Instance.timer.value -= 0.5f;
        }
        ButtonManager.Instance.enviornmentManager.GetComponent<EnviromentMovement>().moveSpeed = 7.8f;
    }
}
