using System.Collections;
using UnityEngine;

public class Spikes : MonoBehaviour
{

  private void OnTriggerEnter2D(Collider2D collision)
    {
    if(collision.CompareTag("Player"))
      {

      StartCoroutine(HurtPlayer(collision));
      }
    }

    private IEnumerator HurtPlayer(Collider2D collision){
      PlayerHealth.instance.TakeDamage(20);
    yield return new WaitForSeconds(0.5f);
    }
}
