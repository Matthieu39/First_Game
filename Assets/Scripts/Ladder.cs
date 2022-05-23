using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
  public bool IsInRange;
  private PlayerMovement playerMovement;
  public BoxCollider2D topcollider;

    void Awake()
    {
      playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
      if (IsInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.DownArrow)) {
        playerMovement.isClimbing = false;
        topcollider.isTrigger = false;
        return;

      }

      if (IsInRange && Input.GetKeyDown(KeyCode.UpArrow)) {
        playerMovement.isClimbing = true;
        topcollider.isTrigger = true;
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
      {
      if(collision.CompareTag("Player"))
        {
          IsInRange = true;
        }
      }

    private void OnTriggerExit2D(Collider2D collision)
      {
        if(collision.CompareTag("Player"))
          {
            IsInRange = false;
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;

          }
      }
}
