using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public InventoryObject inventory;
    public QuestGiver giver;
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other);
        var item = other.GetComponent<GroundItem>();
        if (item)
        {

            Item _item = new Item(item.item);
            //Debug.Log(_item.Id);
            Destroy(other.gameObject);
            inventory.AddItem(_item, 1);
            for (int i = 0; i < giver.quests.Length; i++)
            {
                for (int j = 0; j < giver.quests[i].MyCollectObjectives.Length; j++)
                {
                 //   Debug.Log(inventory.GetAmmount(_item));     
                    giver.quests[i].MyCollectObjectives[j].UpdateItemCount(_item,inventory.GetAmmount(_item));
                }
               
            }
            
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Load();
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[20];
    }
}