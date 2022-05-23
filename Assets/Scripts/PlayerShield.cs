using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    //On crée des collider pour les boucliers droite et gauche + le sprite renderer pour connaitre le sens 
    // On ajoute un GameObject pour avoir celui du joueur
    public GameObject player;
    public Transform shieldRight;
    public Transform shieldLeft;  
    public bool isShielded;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D rb;
    public PlayerMovement playerMovement;
    // Update is called once per frame
    private void Update()
    {   
        // On associe le booléen isShielded directement avec la touche "f"
        isShielded = Input.GetKey("f");
        // On met l'animation du Joueur
        animator.SetBool("Shielded", isShielded);
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        Shield(isShielded);

    }
    
    void Shield(bool _isShielded){
        CapsuleCollider2D shieldColliderRight = shieldRight.GetComponent<CapsuleCollider2D>();
        CapsuleCollider2D shieldColliderLeft = shieldLeft.GetComponent<CapsuleCollider2D>();
        //Le bouclier ne s'active que si on appuie sur "f", si le perso est dans le bon sens et qu'il est immobile
        //Cas où le bouclier est à droite
        if (_isShielded == true && spriteRenderer.flipX == false && rb.velocity.x < 0.3 && Input.GetKey("right") == false && Input.GetKey("left")==false)
        {
            shieldColliderRight.enabled = true;
            shieldColliderLeft.enabled = false;
        //On change le tag du joueur pour éviter des dégats qd le bouclier est actif
            player.tag = "Protection";
            rb.mass=1000; 
        }
        //Cas où il est à gauche
        else if (_isShielded == true && spriteRenderer.flipX == true && rb.velocity.x < 0.3 && Input.GetKey("right") == false && Input.GetKey("left")==false)
        {
            shieldColliderLeft.enabled = true;
            shieldColliderRight.enabled = false;
            player.tag = "Protection"; 
;           rb.mass=1000; 
        }
        //Cas où on appuie pas sur la touche "f"
        else
        {
            shieldColliderRight.enabled = false;
            shieldColliderLeft.enabled = false;
            player.tag = "Player";
            rb.mass=1; 
        }

    }
}
