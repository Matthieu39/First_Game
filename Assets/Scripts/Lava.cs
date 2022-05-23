using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
    {
    if(collision.CompareTag("Player"))
      {

      StartCoroutine(MeltPlayer(collision));
      }
    }

    private IEnumerator MeltPlayer(Collider2D collision){
    yield return new WaitForSeconds(0.5f);
    PlayerHealth.instance.Die();
    }
}
