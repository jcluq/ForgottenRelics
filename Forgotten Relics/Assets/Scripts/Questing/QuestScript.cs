using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestScript : MonoBehaviour
{

    public Quest MyQuest { get; set; }


    private bool markedComplete = false;    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        GetComponent<TextMeshProUGUI>().color = Color.red;
        QuestLog.MyInstance.ShowDescription(MyQuest);
      //  Debug.Log("Selected");

    }

    public void Deselect()
    {
        GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    public void IsComplete()
    {
        if (MyQuest.IsComplete && !markedComplete)
        {
            markedComplete = true;
            GetComponent<TextMeshProUGUI>().text += "(Complete)";
        }
      
    }
}
