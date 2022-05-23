using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool isAttacking;

    public GameObject swordRight;
    public GameObject swordLeft;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        isAttacking = Input.GetKey("e");
        animator.SetBool("Attacking", isAttacking);
    }

    void FixedUpdate()
    {
        Attack(isAttacking);
    }
    void Attack(bool _isAttacking)
    {
        BoxCollider2D swordRightCol = swordRight.GetComponent<BoxCollider2D>();
        BoxCollider2D swordLeftCol = swordLeft.GetComponent<BoxCollider2D>();

        if (_isAttacking == true && spriteRenderer.flipX == false)
        {
            swordRightCol.enabled = true;
            swordLeftCol.enabled = false;
        }
        else if (_isAttacking == true && spriteRenderer.flipX == true)
        {
            swordRightCol.enabled = false;
            swordLeftCol.enabled = true;
        }
        else
        {
            swordRightCol.enabled = false;
            swordLeftCol.enabled = false;
        }
    }
}

