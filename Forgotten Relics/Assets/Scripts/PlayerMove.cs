using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove
{

    private string[] staticD = { "charStatic NE", "charStatic SE", "charStatic SW", "charStatic NW" };
    private string[] moveD = { "charRun NE", "charRun SE", "charRun SW", "charRun NW" };

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            FindSelectableTerrains();
            CheckMouse();
            setStaticAnim();
        }
        else
        {
            Move();
            setMoveAnim();
        }
       // transform.forward = Camera.main.transform.forward;
    }

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Terrain")
                {
                    Terrain t = hit.collider.GetComponent<Terrain>();

                    if (t.selectable)
                    {
                        MoveToTerrain(t);
                    }
                }
            }
        }
    }

    public void setStaticAnim()
    {
        float rot = transform.rotation.eulerAngles.y;
        if (rot < 0)
        {
            rot += 360;
        }

        if(rot == 0)
        {
            anim.Play(staticD[3]);
        }
        else if (rot == 90)
        {
            anim.Play(staticD[0]);
        }
        else if (rot == 180)
        {
            anim.Play("charStatic SW");
        }
        else
        {
            anim.Play("charStatic SE");
        }

    }

    public void setMoveAnim()
    {
        float rot = transform.rotation.eulerAngles.y;
        Debug.Log(rot);
        if (rot < 0)
        {
            rot += 360;
        }

        if (rot == 0)
        {
            anim.Play(moveD[3]);
            
        }
        else if (rot == 90)
        {
            anim.Play(moveD[0]);
            
        }
        else if (rot == 180)
        {
            anim.Play("charRun SW");
        }
        else if (rot == 270)
        {
            anim.Play("charRun SE");
        }
    }
}