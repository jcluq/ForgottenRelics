using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestLog : MonoBehaviour
{
    [SerializeField]
    private GameObject questPrefab;
    [SerializeField]
    private Transform questParent;

    private Quest selectedQuest;

    private  static QuestLog instance;

    public CanvasGroup canvasGroup;

    private List<QuestScript> questScripts = new List<QuestScript>();

    public List<Quest> quests = new List<Quest>();

   

    [SerializeField]
    private TextMeshProUGUI questDescription;

    public static QuestLog MyInstance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<QuestLog>();

            }
            return instance;
        }
    }




    
    public void AcceptQuest(Quest quest)
    {


        quests.Add(quest);
        GameObject go = Instantiate(questPrefab,questParent);

        QuestScript qs = go.GetComponent<QuestScript>();
        quest.MyQuestScript = qs;
        qs.MyQuest = quest;
        questScripts.Add(qs);


        go.GetComponent<TextMeshProUGUI>().text = quest.MyTitle;
        CheckCompletion();
    }


    public void UpdateSelected()
    {
        ShowDescription(selectedQuest);
    }
    public void ShowDescription(Quest quest)
    {
        if (quest != null)
        {
            if (selectedQuest != null)
            {
                selectedQuest.MyQuestScript.Deselect();

            }

                string objectives = "\nObjectives\n";

                selectedQuest = quest;

                string title = quest.MyTitle;
                string desc = quest.MyDescription;

                foreach (Objective obj in quest.MyCollectObjectives)
                {
                    objectives += obj.MyType + ": " + obj.CurrentAmount + "/" + obj.MyAmount + "\n";
                }

                questDescription.text = string.Format("<b>{0}</b>\n\n <size=10>{1}{2}\n\n Reward:</size>", title, desc, objectives);
        }
    }

    public void CheckCompletion()
    {
        foreach (QuestScript qs in questScripts)
        {
            qs.IsComplete();
        }
    }

    public void OpenClose()
    {

        Animator anim = this.GetComponent<Animator>();


        anim.SetBool("Open", !anim.GetBool("Open"));
    }

    public void Close()
    {
        Animator anim = this.GetComponent<Animator>();


        anim.SetBool("Open",false);
    }

    public bool HasQuest(Quest quest)
    {
        return quests.Exists(x => x.MyTitle == quest.MyTitle);
    }

    public void AbandonQuest()
    {

    }
}
