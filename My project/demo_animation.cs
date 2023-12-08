using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo_animation : MonoBehaviour
{
    public Char1_DiChuyen char1;
    public Char2_DiChuyen char2;
    public Char3_DiChuyen char3;
    public Char4_DiChuyen char4;
    public Char5_DiChuyen char5;


    void Start()
    {
        float currentXPosition = transform.position.x;
        if(currentXPosition == 5f)
        {
            char1.StopCharacterMovement();
        }    
    }

}