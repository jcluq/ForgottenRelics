using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnkeeperTile : MonoBehaviour
{
    public Terrain Tile;
    public QuestGiverWindow cg;
    private bool en = false;
    
    // Start is called before the first frame update
    void Start()
    {
        cg.Close();
    }

    // Update is called once per frame
    void Update()
    {
         
       
    if (Tile.current && en == false)
        {
            en = true;
            cg.Open();
            

        }
        
    if (!Tile.current && en == true)
        {
            cg.Close();
            
            en = false;
        }
    }

    
    
}
