using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sprite;

    public bool isAttackingBowRight;
    public bool isAttackingBowLeft;

    void Update()
    {
        isAttackingBowRight = Input.GetKey("r") && !sprite.flipX;
        isAttackingBowLeft = Input.GetKey("r") && sprite.flipX;
        animator.SetBool("AttackBowLeft", isAttackingBowLeft);
        animator.SetBool("AttackBowRight", isAttackingBowRight);
    }
}
