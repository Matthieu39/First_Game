using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerMovement PlayerMovement;

    private GameObject player;
    public float timeOffset;
    public float crouchTimeOffset;
    public Vector3 posOffset;
    public Vector3 crouchPosOffset;

    private Vector3 velocity;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.isCrouched  &&  PlayerMovement.characterVelocity < 0.3f )
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + crouchPosOffset, ref velocity, crouchTimeOffset);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        }
        
    }
}
