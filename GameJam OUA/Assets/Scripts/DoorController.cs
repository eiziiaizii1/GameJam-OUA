using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isDoorOpen = false;
    [SerializeField] GameObject player;
    BoxCollider2D colliderDoor;

    void Start()
    {
        animator = GetComponent<Animator>();
        colliderDoor = GetComponent<BoxCollider2D>();
        animator.SetBool("doorOpen", false);
    }

    void Update()
    {
        if (player != null)
        {
            float distanceFromPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);

            if (Input.GetKeyDown(KeyCode.E) && distanceFromPlayer <= 2.5f)
            {
                Debug.Log("door interaction");
                isDoorOpen = !isDoorOpen;
                animator.SetBool("doorOpen", isDoorOpen);
                colliderDoor.enabled = !isDoorOpen;
                SoundManager.Instance.PlayEffectSound(SoundManager.Instance.DoorSound);
            }
        }
    }
}
