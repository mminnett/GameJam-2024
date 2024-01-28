using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;


    public static EnemyManager Instance 
    { 
        get  
        {

            if (instance == null)
            {
                instance = FindObjectOfType<EnemyManager>();
            }
            return instance; 
        } 
    }

    public List<GameObject> enemyList1;
    public List<GameObject> enemyList2;
    public List<GameObject> enemyList3;
    public List<GameObject> enemyList4;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }    
    }
}
