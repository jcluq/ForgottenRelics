    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventory; // Assign in inspector
    public GameObject questJournal;
    public bool isShowing;

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            isShowing = !isShowing;
            inventory.SetActive(isShowing);

          
        }
        if (Input.GetKeyDown("j"))
        {
            isShowing = !isShowing;
            questJournal.SetActive(isShowing);
        }
    }

     
   

    public void toggle()
    {
       
        
    }
}