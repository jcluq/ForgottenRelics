using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestGiverWindow : Window
{
    private static QuestGiverWindow instance;
    // Start is called before the first frame update
    public QuestGiver qgiver;
    public GameObject questPrefab;

    public Transform questArea;

    private List<GameObject> quests = new List<GameObject>();

    private Quest selected;
 

    public GameObject backbtn, acceptbtn, description,deschold, completebtn, rewardsprite;

    public ItemDatabaseObject db;
    public InventoryObject playerInv;

    public static QuestGiverWindow Instance {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestGiverWindow>();
            }
            return instance;
        }
    } 
        


    public void ShowQuests(QuestGiver qgiver)
    {
        questArea.gameObject.SetActive(true);
        deschold.gameObject.SetActive(false);

        foreach (GameObject go in quests)
        {
            Destroy(go);
        }
        {

        }

        foreach (Quest quest in qgiver.quests)
        {
            if (quest != null)
            {
                GameObject go = Instantiate(questPrefab, questArea);
                go.GetComponent<TextMeshProUGUI>().text = quest.MyTitle;
                go.GetComponent<qgQuestScript>().MyQuest = quest;
                quests.Add(go);

                if (QuestLog.MyInstance.HasQuest(quest) && quest.IsComplete)
                {
                    go.GetComponent<TextMeshProUGUI>().text += "(C)";
                }
                else if (QuestLog.MyInstance.HasQuest(quest))
                {
                    Color c = go.GetComponent<TextMeshProUGUI>().color;

                    c.a = 0.5f;
                    go.GetComponent<TextMeshProUGUI>().color = c;
                }
            }
        }


    }

    public override void Open()
    {
        ShowQuests(qgiver);
        base.Open();
    }

    public override void Close()
    {
        completebtn.SetActive(false);
        base.Close();
    }

    public void ShowQuestInfo(Quest quest)
    {
        this.selected = quest;

        if (QuestLog.MyInstance.HasQuest(quest) && quest.IsComplete)
        {
            completebtn.SetActive(true);
            acceptbtn.SetActive(false);  
        }
        else if (!QuestLog.MyInstance.HasQuest(quest))
        {
            acceptbtn.SetActive(true);
        }


        backbtn.SetActive(true);
       // acceptbtn.SetActive(true);
        questArea.gameObject.SetActive(false);
        deschold.gameObject.SetActive(true);


        string objectives = "\nObjectives\n";

        
        
        string title = quest.MyTitle;
        string desc = quest.MyDescription;
        

        foreach (Objective obj in quest.MyCollectObjectives)
        {
            objectives += obj.MyType + ": " + obj.CurrentAmount + "/" + obj.MyAmount + "\n";
        }

        rewardsprite.transform.GetChild(0).GetComponentInChildren<Image>().sprite = db.GetItem[quest.reward.Id].uiDisplay;

        Debug.Log("her");
        description.GetComponent<TextMeshProUGUI>().text = string.Format("<b>{0}</b>\n <size=10>{1}\n\n{2}\n\n Reward:</size>", title, desc, objectives, "Reward");
    }

    public void Back()
    {
        backbtn.SetActive(false);
        acceptbtn.SetActive(false);
        ShowQuests(qgiver);
        completebtn.SetActive(false);

    }

    public void Accept()
    {
        QuestLog.MyInstance.AcceptQuest(selected);
        Back();
    }

    public void CompleteQuest()
    {
        if (selected.IsComplete)
        {
            for (int i = 0; i < qgiver.quests.Length; i++)
            {
                if(selected == qgiver.quests[i])
                {
                    qgiver.quests[i] = null;
                    playerInv.AddItem(selected.reward,1);
                   // QuestLog.MyInstance.quests.);
                    //
                }
            }Back();
        }
    }
}

