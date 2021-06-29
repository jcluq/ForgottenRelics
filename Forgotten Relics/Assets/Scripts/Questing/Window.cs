using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;

    public virtual void Open()
    {
      
            Animator anim = this.GetComponent<Animator>();


            anim.SetBool("Open", true);
        
    }

    public virtual void Close()
    {
        Animator anim = this.GetComponent<Animator>();


        anim.SetBool("Open", false);
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
