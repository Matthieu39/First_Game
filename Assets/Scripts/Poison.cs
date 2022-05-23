using System.Collections;
using UnityEngine;

public class Poison : MonoBehaviour
{
public bool isInPoison;
public bool isPoisoned;


 void Update()
{
  if(isPoisoned && PlayerHealth.instance.currentHealth > PlayerHealth.instance.maxHealthWhenPoisoned && PlayerHealth.instance.currentHealth < PlayerHealth.instance.maxHealth)
    {
      PlayerHealth.instance.maxHealth = PlayerHealth.instance.currentHealth;
    }
      else if (isPoisoned && PlayerHealth.instance.currentHealth < PlayerHealth.instance.maxHealthWhenPoisoned)
    {
      PlayerHealth.instance.maxHealth = PlayerHealth.instance.maxHealthWhenPoisoned;
    }



  if(!isPoisoned && PlayerHealth.instance.isInvincible == false)
    {
    PlayerHealth.instance.maxHealth = PlayerHealth.instance.maxHealthWhenHealed;
    PlayerHealth.instance.graphics.color = new Color(1f, 1f, 1f, 1f);
    }
  PlayerHealth.instance.healthBar.SetHealth(PlayerHealth.instance.currentHealth);
}


private void OnTriggerEnter2D(Collider2D collision)
  {
  if(collision.CompareTag("Player"))
    {
      isInPoison = true;
      isPoisoned = true;
      StartCoroutine(IsPoisonedState());

    }
    if(isInPoison){
      StartCoroutine(IntoxicPlayer());
    }

  }

private void OnTriggerExit2D(Collider2D collision)
  {
    if(collision.CompareTag("Player"))
      {
        isInPoison = false;
      }
  }


    private IEnumerator IntoxicPlayer(){
    PlayerHealth.instance.PoisonDamage(1);
    yield return new WaitForSeconds(0.2f);
    if(isInPoison){
      StartCoroutine(IntoxicPlayer());
    }
    }

    private IEnumerator IsPoisonedState(){
      while (isPoisoned) {
        PlayerHealth.instance.graphics.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.15f);
      PlayerHealth.instance.graphics.color = new Color(0f, 1f, 0f, 1f);
        yield return new WaitForSeconds(0.3f);
      }
    }




}
