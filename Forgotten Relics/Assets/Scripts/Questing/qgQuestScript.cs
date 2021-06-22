using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qgQuestScript : MonoBehaviour
{

    public Quest MyQuest;

    public void Select()
    {
        Debug.Log("tamos");
        QuestGiverWindow.Instance.ShowQuestInfo(MyQuest);
    }
}
