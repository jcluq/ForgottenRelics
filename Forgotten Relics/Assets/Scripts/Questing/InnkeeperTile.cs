using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnkeeperTile : MonoBehaviour
{
    public Terrain Tile;
    public QuestGiverWindow cg;
    private bool en = false;
    Animator anim;

    // Start is called before the first frame update


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
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
            anim.SetBool("Open", true);

        }
        
    if (!Tile.current && en == true)
        {
            cg.Close();
            anim.SetBool("Open", false);

            en = false;
        }
    }

    
    
}
