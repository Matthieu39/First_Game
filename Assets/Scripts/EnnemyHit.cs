using UnityEngine;

public class EnnemyHit : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;

    public float knockbackForce = 150;
    public float ennemyLife = 30;

    void Awake()
    {
        spriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        animator.SetFloat("Life", ennemyLife);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (spriteRenderer.flipX == false)
        {
            if (collision.CompareTag("Weapon"))
            {
                ennemyLife -= 10;
                KillEnnemy(ennemyLife);
                rb.AddForce(new Vector2(knockbackForce, knockbackForce));
            }

            if (collision.CompareTag("Arrow"))
            {
                ennemyLife -= 5;
                KillEnnemy(ennemyLife);
                rb.AddForce(new Vector2(knockbackForce * 0.75f, knockbackForce * 0.75f));
            }

            if (collision.CompareTag("StrongSword"))
            {
                ennemyLife -= 20;
                KillEnnemy(ennemyLife);
                rb.AddForce(new Vector2(knockbackForce * 1.25f, knockbackForce * 1.25f));
            }
        }

        if (spriteRenderer.flipX == true)
        {
            if (collision.CompareTag("Weapon"))
            {
                ennemyLife -= 10;
                KillEnnemy(ennemyLife);
                rb.AddForce(new Vector2(-knockbackForce, knockbackForce));
            }

            if (collision.CompareTag("Arrow"))
            {
                ennemyLife -= 5;
                KillEnnemy(ennemyLife);
                rb.AddForce(new Vector2(-knockbackForce * 0.75f, knockbackForce * 0.75f));
            }

            if (collision.CompareTag("StrongSword"))
            {
                ennemyLife -= 20;
                KillEnnemy(ennemyLife);
                rb.AddForce(new Vector2(-knockbackForce * 1.25f, knockbackForce * 1.25f));
            }
        }

    }


    void KillEnnemy(float _ennemyLife)
    {
        if(_ennemyLife <= 0)
        {
            Destroy(objectToDestroy);
            Inventory.instance.AddCoins(20);
        }
    }

}
