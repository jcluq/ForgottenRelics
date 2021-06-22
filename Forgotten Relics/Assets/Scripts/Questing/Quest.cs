using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [SerializeField]
    private string title;

    [SerializeField]
    private string description;

    [SerializeField]
    private CollectObjective[] collectObjectives;

    public InventoryObject playerInventory;

    public Item reward;

   
    public QuestScript MyQuestScript { get; set; }
    public string MyTitle { get => title; set => title = value; }
    public string MyDescription { get => description; set => description = value; }
    public CollectObjective[] MyCollectObjectives { get => collectObjectives; set => collectObjectives = value; }

    public bool IsComplete
    {
        get
        {
            foreach (Objective o in MyCollectObjectives)
            {
                if (!o.isComplete)
                {
                    return false;
                }
            }
            return true;
        }
    }

 




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
   
}
[System.Serializable]
public abstract class Objective
{
    [SerializeField]
    private int amount;
    private int currentAmount;

    [SerializeField]
    private string type;

    public Inventory inventory;

    public int MyAmount { get => amount; }
    public string MyType { get => type; set => type = value; }
    public int CurrentAmount { get => currentAmount; set => currentAmount = value; }
    public bool isComplete
    {
        get
        {
            return (CurrentAmount >= MyAmount);
        }
    }

}




[System.Serializable]
public class CollectObjective : Objective
{
    public void UpdateItemCount(Item item, int count)
    {
        if (MyType.ToLower() == item.Name.ToLower())
        {
            
            for (int i = 0; i < inventory.Items.Length; i++)
            {

              //  Debug.Log(item.Name);
               // Debug.Log(MyType.ToLower());

                if (item.Name.ToLower() == MyType.ToLower())
                {
                    Debug.Log(count);
                    CurrentAmount = count;
                    QuestLog.MyInstance.UpdateSelected();
                    QuestLog.MyInstance.CheckCompletion();
                    return;
                   // Debug.Log(CurrentAmount);
                }
            }

        }
    }
}

