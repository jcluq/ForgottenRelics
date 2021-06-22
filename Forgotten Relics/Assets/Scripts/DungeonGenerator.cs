using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DungeonGenerator : MonoBehaviour
{

    public float scaler = 1.0f;
    public float scalerheight = 3.0f;
    public string seed = "EC2021";

    public bool useSeed = true;
    public bool drawGizmos = true;


    [Range(2, 50)]
    public int mapSize = 10;



    [Range(0, 8)]
    public int fillThreshold = 5;


    [Range(0.01f, 0.99f)]
    public float fill = 0.5f;


    float[,] map;


    public GameObject[] wallPrefabs;


    void Start()
    {
        GenerateMap();
    }


    public void CellularAutomata()
    {
        print("CA started");
        float[,] map2 = new float[mapSize, mapSize];


        for (int x = 1; x < map.GetLength(0) - 1; x++)
        {
            for (int y = 1; y < map.GetLength(1) - 1; y++)
            {

                float sum = 0;
                for (int xi = x - 1; xi < x + 1; xi++)
                {
                    for (int yi = y - 1; yi < y + 1; yi++)
                    {
                        sum += map[xi, yi];
                    }
                }
                if (sum >= fillThreshold)
                {
                    map2[x, y] = 1;
                }
                else
                {
                    map2[x, y] = 0;
                }
            }
        }
        map = map2;
        print("CA finished");
    }

    public void Generate()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        print("generation started");
        map = new float[mapSize, mapSize];
        if (useSeed)
        {
            UnityEngine.Random.InitState(seed.GetHashCode());
        }


        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                //map[x,y] = UnityEngine.Random.value > (1.0f-fill) ? 1 : 0;
                map[x, y] = Mathf.PerlinNoise((UnityEngine.Random.value + x) * scaler,
                    (UnityEngine.Random.value + y) * scaler) * scalerheight;
               /* if (x == 0 || y == 0 || x == (mapSize - 1) || y == (mapSize - 1))
                {
                    map[x, y] = 1;

                }*/
            }
        }
        //CellularAutomata();
        print("generation finished");
    }


    public void PlaceObjects()
    {

        foreach (Transform child in transform)
        {
#if UNITY_EDITOR
            GameObject.DestroyImmediate(child.gameObject);
#else
            GameObject.Destroy(child.gameObject);
#endif
        }

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {

                Vector3 siz = new Vector3(1, Mathf.Round(map[x, y]) * 0.5f, 1);
                Vector3 pos = transform.position + new Vector3(x - map.GetLength(0) / 2 + 0.5f,
                    transform.position.y + (siz.y / 2),
                    y - map.GetLength(1) / 2 + 0.5f);
              


                if (map[x, y] > (1.0 - fill))
                {
                    int idx = UnityEngine.Random.Range(0, wallPrefabs.Length);
                    GameObject newObject  = Instantiate(wallPrefabs[idx],
                        pos,
                        Quaternion.identity, transform);
                    newObject.transform.localScale = siz;
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        if (!drawGizmos)
        {
            return;
        }
        if (map == null)
        {
            return;
        }
         

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {


                Vector3 siz = new Vector3(1, Mathf.Round(map[x, y])*0.5f, 1);
                Vector3 pos = transform.position + new Vector3(x - map.GetLength(0) / 2 + 0.5f,
                    transform.position.y + (siz.y/2),
                    y - map.GetLength(1) / 2 + 0.5f);
                Gizmos.color = Color.white * map[x,y];



               /* if (map[x, y] > 0)
                {
                    Gizmos.color = Color.black;
                }
                else
                {
                    Gizmos.color = Color.white;
                }*/
                Gizmos.DrawCube(pos, siz);
            }
        }


    }
}
