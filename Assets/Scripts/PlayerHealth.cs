using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

public int maxHealth = 100;
public int maxHealthWhenHealed=100;
public int maxHealthWhenPoisoned = 75;
public int currentHealth;
public SpriteRenderer graphics;
public HealthBar healthBar;

public bool isInvincible;

public static PlayerHealth instance;

private void Awake(){

  if(instance != null){
    Debug.LogWarning("Il y a plus d'une instance de Playerhealth dans la scene");
    return ;
    // PERMET DE S SASSURER QU IL N Y A QU UN SEUL INVENTAIRE
    //Singleton
  }
  instance = this;
  currentHealth = maxHealth;
  healthBar.SetMaxHealth(maxHealth);
}


    // Update is called once per frame
    void Update()
    {

      if(currentHealth> maxHealth)
      {
        currentHealth = maxHealth;
      }

      if (Input.GetKeyDown(KeyCode.H)) {
        TakeDamage(60);
      }
    }


    public void Heal(int heal){
      currentHealth += heal;
      healthBar.SetHealth(currentHealth);

      }


  public void TakeDamage(int damage){

      if(!isInvincible){
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);

      // verifier que le joueur est toujours vivant;
      if(currentHealth<= 0){
        Die();
        return;
      }
      isInvincible = true;
      StartCoroutine(InviFlash());
      StartCoroutine(StopInvi());
    }
    }


    public void PoisonDamage(int damage){

        if(!isInvincible){
          healthBar.SetHealth(currentHealth);
        currentHealth -= damage;
        // healthBar.SetHealth(currentHealth);

        // verifier que le joueur est toujours vivant;
        if(currentHealth<= 0){
          Die();
          return;
        }

      }
      }

// test regain de santé
      public void MagicHeal(int recover){

          currentHealth += recover;
          healthBar.SetHealth(currentHealth);

          // verifier que le joueur est toujours vivant;
          // if(currentHealth<= 0){
          //   Die();
          //   return;
          // }

        }





    public void Die(){

      //Bloquer les mouvements du personnage
      PlayerMovement.instance.enabled = false;
      PlayerMovement.instance.animator.SetTrigger("Die");
      PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
      PlayerMovement.instance.rb.velocity = Vector3.zero;
      PlayerMovement.instance.standingCollider.enabled = false;

      GameOverManager.instance.OnPlayerDeath();

    }

    public void Respawn()
    {
      PlayerMovement.instance.enabled = true;
      PlayerMovement.instance.animator.SetTrigger("Respawn");
      PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
      // PlayerMovement.instance.rb.velocity = Vector3.zero;
      PlayerMovement.instance.standingCollider.enabled = true;
      currentHealth = maxHealth;
      healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InviFlash(){

      while (isInvincible) {
        graphics.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(0.15f);
        graphics.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.15f);

      }
    }

    public IEnumerator StopInvi(){
      yield return new WaitForSeconds(2f);
      isInvincible = false;
    }

}
