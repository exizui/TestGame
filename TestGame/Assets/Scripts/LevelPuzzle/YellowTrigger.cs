using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTrigger : MonoBehaviour
{
    public static bool y;
    Animator a;
    private bool f = false;

    private void Start()
    {
        a = GetComponent<Animator>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        Animation();
        y = true;
        Puzzle.puz.ActivePortal();
    }

    private void OnTriggerExit(Collider other)
    {
        Animation();
        y = false;
        Puzzle.puz.ActivePortal();
    }
    void Animation()
    {
        f = !f;
        a.SetBool("isDown", f);
        a.SetBool("isUp", !f);
    }
}
