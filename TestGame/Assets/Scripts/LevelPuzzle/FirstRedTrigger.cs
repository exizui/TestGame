using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class FirstRedTrigger : MonoBehaviour
{
    Animator redbutton;
    private bool f = false;

    private void Start()
    {
        redbutton = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Puzzle.puz.OpenCells();
        Animation();
    }
    
    private void OnTriggerExit(Collider other)
    {
       Puzzle.puz.ClosedCells();
        Animation();
    }

    void Animation()
    {
        f = !f;
        redbutton.SetBool("isDown", f);
        redbutton.SetBool("isUp", !f);
    }
}
