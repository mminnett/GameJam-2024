using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public enum eventType {ENEMY, JUMP, SLIDE, START, FINISH}

    public eventType type;

    public bool isTriggered;

    [SerializeField] private Transform enemySpawn;
    private List<GameObject> enemy = EnemyManager.Instance.enemyList1;  


    private GameObject parent;

    private void Awake()
    {
        parent = transform.parent.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (parent.tag == "EnemyTerrain")
        {
            if (EnemyManager.Instance.enemyList1.Count > 0)
            {
                int i = Random.Range(0, enemy.Count);
                Debug.Log("Spawn 'Enemy'");
                Instantiate(EnemyManager.Instance.enemyList1[i], new Vector3(enemySpawn.position.x, enemySpawn.position.y + 1, enemySpawn.position.z), Quaternion.identity, parent.transform);
                EnemyManager.Instance.enemyList1.Remove(EnemyManager.Instance.enemyList1[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (type)
        {
            case eventType.ENEMY:
                
                break;

            case eventType.JUMP:

                break;

            case eventType.SLIDE:

                break;

            case eventType.START:

                break;

            case eventType.FINISH:
                
                break;
        }
    }
}
