using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "My Game/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public SpriteRenderer enemySprite;
    public int health;
    public int damage;
    public int knockbackForce;
    public int giveCoins;
    public float speedWalk;
    public float speedRun;
    public float playerCheckRadius;
    public float playerAttackProximity;
}
