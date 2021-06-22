using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuScript
{
    [MenuItem("Tools/Assign Terrain Material")]
    public static void AssignTileMaterial()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Terrain");
        Material material = Resources.Load<Material>("Materials/Terrain");

        foreach (GameObject t in tiles)
        {
            t.GetComponent<Renderer>().material = material;
        }
    }

    [MenuItem("Tools/Assign Terrain Script")]
    public static void AssignTileScript()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Terrain");

        foreach (GameObject t in tiles)
        {
            t.AddComponent<Terrain>();
        }
    }
}
