using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PCScript : MonoBehaviour
{

    public InventoryObject inventory;


    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            inventory.Load();
        }
        //  UpdateDisplay();
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[25];
    }
}
   