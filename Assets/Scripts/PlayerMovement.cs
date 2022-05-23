using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

 public float moveSpeed;
 public float jumpForce;
 public float fallforce;
 public float wallJumpForce;

 public bool isJumping;
 private bool isLeftWallJumping;
 private bool isRightWallJumping;
 private bool isWallJumping;

 public bool isGrounded;
 public bool isGroundedBackground;
 public bool isLeftWalled;
 public bool isRightWalled;
 public bool isWalled;
 public bool isSlideRoofed;

 public bool isFalling;
 public bool isCrouched;

 private bool rightMovement;
 private bool leftMovement;

 [HideInInspector]
 public bool isClimbing;

 public Transform groundCheck;
 public float groundCheckRadius;
 public LayerMask collisionLayers;
 public LayerMask collisionBackgroundLayers;

 public Transform leftWallCheckUp;
 public Transform leftWallCheckDown;
 public Transform rightWallCheckUp;
 public Transform rightWallCheckDown;
 public LayerMask wallLayers;
 public Transform slideRoofCheck;
 public float slideRoofCheckRadius;

 public Animator animator;
 public SpriteRenderer spriteRenderer;
 public Rigidbody2D rb;
 public CapsuleCollider2D standingCollider;
 public CapsuleCollider2D crouchedCollider;
 public CapsuleCollider2D slidingCollider;

 private Vector3 velocity = Vector3.zero;

 private float horizontalMovement;
 private float verticalMovement;

 public float characterVelocity;
 public float characterUpVelocity;

 public static PlayerMovement instance;

 private void Awake()
 {

  if(instance != null){
   Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scene");
   return ;
   // PERMET DE S SASSURER QU IL N Y A QU UN SEUL PlayerMovement
   //Singleton
  }
  instance = this;
 }


   void Update()
   {
     characterVelocity = Mathf.Abs(rb.velocity.x);
     characterUpVelocity = rb.velocity.y;

    if(Input.GetButtonDown("Jump") && (isGrounded || isGroundedBackground) && !isClimbing)
       {
         isJumping = true;
       }
       else if (Input.GetButtonDown("Jump") &&  isLeftWalled && !isClimbing)
       {
           isLeftWallJumping = true;
       }
       else if (Input.GetButtonDown("Jump") &&  isRightWalled && !isClimbing)
       {
           isRightWallJumping = true;
       }

       rightMovement = Input.GetKey("right") || Input.GetKey("d");
       leftMovement = Input.GetKey("left") || Input.GetKey("q");

       animator.SetFloat("Jump", characterUpVelocity);
       animator.SetBool("GroundedBackground", isGroundedBackground);
       animator.SetBool("Grounded", isGrounded);
       animator.SetFloat("Velocity", rb.velocity.y);
       animator.SetFloat("Speed", characterVelocity);
       animator.SetBool("Falling", isFalling);
       animator.SetBool("Climbing", isClimbing);
       animator.SetBool("Slide Roofed", isSlideRoofed);

       isCrouched = Input.GetKey("down") && (isGrounded || isGroundedBackground);
       animator.SetBool("Crouched", isCrouched);

       Flip(rb.velocity.x, isLeftWalled, isRightWalled, isGrounded);
       // Flip(rb.velocity.x, isGrounded);

       isWallJumping = isLeftWallJumping || isRightWallJumping;
       isWalled = isLeftWalled || isRightWalled;
       animator.SetBool("Walled", isWalled);

       if ((isGrounded || isGroundedBackground) || isLeftWalled || isRightWalled)
       // if (!isGrounded )

         {
             isFalling = false;
         }
         else
         {
             isFalling = true;
         }

   }

   void FixedUpdate()
   {

     isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
     isGroundedBackground = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionBackgroundLayers);
     isLeftWalled = Physics2D.OverlapArea(leftWallCheckUp.position, leftWallCheckDown.position, wallLayers);
     isRightWalled = Physics2D.OverlapArea(rightWallCheckUp.position, rightWallCheckDown.position, wallLayers);
     isSlideRoofed = Physics2D.OverlapCircle(slideRoofCheck.position, slideRoofCheckRadius, wallLayers);
     

     horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
     verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

     MovePlayer(horizontalMovement,verticalMovement);

   }






 void MovePlayer(float _horizontalMovement, float _verticalMovement)
 {
    if(!isClimbing)
    {
          Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
          rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .1f);
    }
    else
    {
        //deplacement vertical
        Vector3 targetVelocity = new Vector2(0, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .1f);
     }

     if(isJumping == true)
     {
        rb.AddForce(new Vector2(0f,jumpForce));
        isJumping = false;
     }

    else if (leftMovement== false  &&  isLeftWallJumping == true  &&  isGrounded == false  &&  rb.velocity.y < 3f)
    {
        rb.AddForce(new Vector2(wallJumpForce, jumpForce));
        isLeftWallJumping = false;
    }
    else if (rightMovement == false  &&  isRightWallJumping == true  &&  isGrounded == false  &&  rb.velocity.y < 3f)
    {
        rb.AddForce(new Vector2(-wallJumpForce, jumpForce));
        isRightWallJumping = false;
    }

  float hM = _horizontalMovement;
  if (isCrouched  &&  Mathf.Abs(hM) < 0.2)
  {
      standingCollider.enabled = false;
      crouchedCollider.enabled = true;
      slidingCollider.enabled = false;
      hM = 0;
      moveSpeed = 0;

  }
  else if (isCrouched  &&  Mathf.Abs(hM) > 0.2){
      standingCollider.enabled = false;
      crouchedCollider.enabled = false;
      slidingCollider.enabled = true;
      if (moveSpeed >= 0)
      {
          moveSpeed -= 1.5f;
      }
  }
  else if (isCrouched == false && isSlideRoofed == false)
  {
      standingCollider.enabled = true;
      crouchedCollider.enabled = false;
      slidingCollider.enabled = false;
      hM = _horizontalMovement;
      moveSpeed = 250;
  }

  if (isFalling && Input.GetKey("down"))
  {
      rb.AddForce(new Vector2(0f, -fallforce));
  }
 }




   void Flip(float _velocity, bool _isLeftWalled, bool _isRightWalled, bool _isGrounded)
   // void Flip(float _velocity, bool _isGrounded)

     {

     if(_velocity >0.3f)
   {
     spriteRenderer.flipX = false;
   }
   else if (_velocity < -0.3f)
   {
     spriteRenderer.flipX = true;
   }
   else if(_isLeftWalled == true && _isGrounded == false)
   {
    spriteRenderer.flipX = true;
   }
   else if(_isRightWalled == true && _isGrounded == false)
   {
    spriteRenderer.flipX = false;
   }
   }

   private void OnDrawGizmos()
   {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

    Gizmos.color = Color.blue;
    Gizmos.DrawLine(leftWallCheckUp.position, leftWallCheckDown.position);
    Gizmos.DrawLine(rightWallCheckUp.position, rightWallCheckDown.position);

    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(slideRoofCheck.position, slideRoofCheckRadius);
   }

}
