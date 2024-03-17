using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isDoorOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isDoorOpen = !isDoorOpen;
            animator.SetBool("doorOpen", isDoorOpen);
        }
    }
}
