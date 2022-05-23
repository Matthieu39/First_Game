using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayerTest : MonoBehaviour
{
  public bool isHealing;

  private void OnTriggerEnter2D(Collider2D collision)
    {
    if(collision.CompareTag("Player"))
      {
        isHealing = true;
      }
      if(isHealing){
        StartCoroutine(HealPlayer());
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
      {
        if(collision.CompareTag("Player"))
          {
            isHealing = false;
          }
      }

      private IEnumerator HealPlayer(){
      PlayerHealth.instance.MagicHeal(1);
      yield return new WaitForSeconds(0.2f);
      if(isHealing){
        StartCoroutine(HealPlayer());
      }

      }

}
