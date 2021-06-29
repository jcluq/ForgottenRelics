using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimation : MonoBehaviour
{
    private string[] staticD = { "charStatic NE", "charStatic SE", "charStatic SW", "charStatic NW" };
    private string[] moveD = { "charRun NE", "charRun SE", "charRun SW", "charRun NW" };
    private Animator anim;

    int lastDirection;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void SetDirection(Vector3 _direction)
    {
        string[] directionArray = null;

        if(_direction.magnitude < 0.01)
        {
            directionArray = staticD;
        }
        else
        {
            directionArray = moveD;
           // lastDirection = directionToIndex(_direction);
        }

        anim.Play(directionArray[lastDirection]);
    }

    public void directionToIndex(Vector3 _direction)
    {
        Vector3 norDir = _direction.normalized;

        float step = 360 / 4;
       
        float angle = Vector3.SignedAngle(Vector3.forward, norDir,Vector3.up);
    }
}
