using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAttack : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sprite;
    public PlayerMovement playerMovement;
    public Rigidbody2D rb;

    private Vector3 velocity = Vector3.zero;

    public bool isAttackingStrong;
    public bool strongJump = false;
    public bool strongFall = false;
    public bool canIsMove = true;
    public bool isExhausted = false;
   
    public int strongJumpForce;
    public int strongFallForce;


    public void Start()
    {
    }
    void Update()
    {
        isAttackingStrong = Input.GetKey("t") && !isExhausted;
        animator.SetBool("AttackStrong", isAttackingStrong);

        if (isExhausted)
        {
            StartCoroutine(TakeRest());
        }
    }

    private void FixedUpdate()
    {
        if (strongJump)
        {
            rb.AddForce(new Vector2(0, strongJumpForce));
        }

        if (strongFall)
        {
            rb.AddForce(new Vector2(0, -strongFallForce));
            //isExhausted = true;
        }

        if (canIsMove)
        {
            playerMovement.moveSpeed = 250;
        }
        else
        {
            playerMovement.moveSpeed = 0;
        }
    }

    private IEnumerator TakeRest()
    {
        yield return new WaitForSeconds(20f);
        isExhausted = false;
    }
}
