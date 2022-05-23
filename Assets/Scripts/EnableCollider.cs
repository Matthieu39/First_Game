using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCollider : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private BoxCollider2D[] cols;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        cols = gameObject.GetComponents<BoxCollider2D>();

        if (playerMovement.rb.velocity.y < 0)
        {
            foreach (BoxCollider2D value in cols)
            {
                value.isTrigger = false;
            }
        }

        if (playerMovement.rb.velocity.y > 0 || playerMovement.isGrounded)
        {
            foreach (BoxCollider2D value in cols)
            {
                value.isTrigger = true;
            }
        }
    }
}