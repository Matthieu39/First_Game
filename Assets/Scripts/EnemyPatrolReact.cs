using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolReact : MonoBehaviour
{
    public EnemyData enemyData;

    public SpriteRenderer spriteEnemy;

    private int destPoint =0 ;
    public bool playerDetected;
    public float speed;

    public Transform[] waypoints;
    public Transform playerCheck;
    public Transform player;
    private Transform target;

    public LayerMask playerLayers;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
      speed = enemyData.speedWalk;
      target= waypoints[0];
      enemyData.speedRun = 3f*enemyData.speedWalk;
      
    }
    // Update is called once per frame
    void Update()
    {
      //On définit la direction que doit prendre l'ennemi
      Vector3 dir = target.position - transform.position;
      transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
      //EnemyReact(playerDetected);
      if(playerDetected){
        target=player; //le joueur devient la cible
        speed = enemyData.speedRun; //on augmente la vitesse de l'ennemi
      }
      //si ennemi presque arrivé à destination
      if(Vector3.Distance(transform.position, target.position) < 0.3f /*&& playerDetected==false*/){
        destPoint = (destPoint +1) % waypoints.Length;
        target = waypoints[destPoint];
        speed = enemyData.speedWalk;
        spriteEnemy.flipX = !spriteEnemy.flipX;
      }

      animator.SetBool("Player Detected", playerDetected);      
    }
    void FixedUpdate(){
      //détection de player dans le playerCheck
      playerDetected = Physics2D.OverlapCircle(playerCheck.position, enemyData.playerCheckRadius, playerLayers);
      //appel de EnemyReact
    }
    private void OnCollisionEnter2D(Collision2D collision){

      if (collision.transform.CompareTag("Player")) {
        PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(20);
        Debug.Log("L'ennemi a touché le joueur.");
      }
      if (collision.transform.CompareTag("Protection")) {
        Debug.Log("L'ennemi a touché le bouclier.");
      }
    }
    private void OnDrawGizmos()
   {
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(playerCheck.position, enemyData.playerCheckRadius);
    }
}
