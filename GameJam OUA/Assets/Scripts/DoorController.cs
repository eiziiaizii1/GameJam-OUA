using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isDoorOpen = false;
    [SerializeField] GameObject player;
    Color initialColor;
    Color closedDoor;

    // INSTEAD OF COLOR, CHANGE THE SPRITE to closed door sprite 

    void Start()
    {
        initialColor = gameObject.GetComponent<SpriteRenderer>().color;
        closedDoor = new Color(initialColor.r, initialColor.g, initialColor.b, 0.5f);
    }

    void Update()
    {
        float distanceFromPlayer =Mathf.Abs(player.transform.position.x - transform.position.x);

        if (Input.GetKeyDown(KeyCode.E) && distanceFromPlayer <= 2f)
        {
            isDoorOpen = !isDoorOpen;
            gameObject.GetComponent<BoxCollider2D>().enabled = isDoorOpen;
            if (!isDoorOpen)
            {
                gameObject.GetComponent<SpriteRenderer>().color = closedDoor;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = initialColor;
            }
            animator.SetBool("doorOpen", isDoorOpen);
        }
    }
}
