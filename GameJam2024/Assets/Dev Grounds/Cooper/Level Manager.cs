using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private static LevelManager instance;

    public static LevelManager Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
            }
            return instance;
        }
    }

    public enum TerrainType { MEDIEVAL, FOOD, MODERN, SCIFI };

    public TerrainType type;

    [SerializeField] private List<GameObject> terrainPrefabs_1;
    [SerializeField] private List<GameObject> terrainPrefabs_2;
    [SerializeField] private List<GameObject> terrainPrefabs_3;
    [SerializeField] private List<GameObject> terrainPrefabs_4;
    [SerializeField] private List<GameObject> startingTerrain;
    [SerializeField] private List<GameObject> bossTerrain;

    [SerializeField] private Transform startPoint;

    // Start is called before the first frame update
    void Start()
    {
        type = TerrainType.FOOD;
        GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GenerateTerrain()
    {
        Vector3 lastPos = new Vector3(0, startPoint.position.y, 0);
        Vector3 nextPos = lastPos;

        Instantiate(startingTerrain[0], nextPos, Quaternion.identity, startPoint);

        /////////////////////////////////////
        //FOOD
        /////////////////////////////////////

        Debug.Log("Terrain Created FOOD");

        for (int i = 0; i < 12; i++)
        {
            nextPos = lastPos + new Vector3(20, 0, 0);

            if (i % 2 == 0)
            {
                Instantiate(terrainPrefabs_1[0], nextPos, Quaternion.identity, startPoint);
            }
            else
            {
                Instantiate(terrainPrefabs_1[Random.Range(1, 3)], nextPos, Quaternion.identity, startPoint);
            }
            lastPos = nextPos;
        }
        /////////////////////////////////////
        //MEDIEVAL
        /////////////////////////////////////
        Debug.Log("Terrain Created MEDIEVAL");

        for (int i = 0; i <= 12; i++)
        {
            nextPos = lastPos + new Vector3(20, 0, 0);

            if (i % 2 == 0)
            {
                Instantiate(terrainPrefabs_2[0], nextPos, Quaternion.identity, startPoint);
            }
            else
            {
                Instantiate(terrainPrefabs_2[Random.Range(1, 3)], nextPos, Quaternion.identity, startPoint);
            }
            lastPos = nextPos;
        }

        /////////////////////////////////////
        //MODERN
        /////////////////////////////////////
        Debug.Log("Terrain Created MODERN");

        for (int i = 0; i <= 12; i++)
        {
            nextPos = lastPos + new Vector3(20, 0, 0);

            if (i % 2 == 0)
            {
                Instantiate(terrainPrefabs_3[0], nextPos, Quaternion.identity, startPoint);
            }
            else
            {
                Instantiate(terrainPrefabs_3[Random.Range(1, 3)], nextPos, Quaternion.identity, startPoint);
            }
            lastPos = nextPos;
        }

        /////////////////////////////////////
        //FUTURE
        /////////////////////////////////////
        Debug.Log("Terrain Created SCIFI");

        for (int i = 0; i <= 12; i++)
        {
            nextPos = lastPos + new Vector3(20, 0, 0);

            if (i % 2 == 0)
            {
                Instantiate(terrainPrefabs_4[0], nextPos, Quaternion.identity, startPoint);
            }
            else
            {
                Instantiate(terrainPrefabs_4[Random.Range(1, 3)], nextPos, Quaternion.identity, startPoint);
            }
            lastPos = nextPos;
        }

        /////////////////////////////////////
        //Boss
        /////////////////////////////////////
        for (int i = 0; i <= 3; i++)
        {
            nextPos = lastPos + new Vector3(20, 0, 0);

            if (i == 0)
            {
                Instantiate(bossTerrain[0], nextPos, Quaternion.identity, startPoint);

            }
            else
            {
                Instantiate(bossTerrain[1], nextPos, Quaternion.identity, startPoint);
            }
            lastPos = nextPos;
        }
    }
}
