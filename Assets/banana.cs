using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour
{
    private Rigidbody2D RB;
    public GameObject GameEvent;
    private Vector2 _awakeVelocity;
    public GameObject player;
    public GameObject Enemy;
    private GameObject HealthPlayer;
    private GameObject HealthEnemy;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        GameEvent = GameObject.Find("GameEvent");
        HealthEnemy = GameObject.Find("Ennemie");
        HealthPlayer = GameObject.Find("Player");
    }

    public void SetAngle(Vector2 angle_vector, float force)
    {
        _awakeVelocity = angle_vector * force;
        RB.velocity = _awakeVelocity;
    }

    private void FixedUpdate()
    {
        RB.velocity += GameEvent.GetComponent<GameEventScript>().wind * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && (gameObject.CompareTag("Projectile")))
        {
            Destroy(gameObject);
            HealthEnemy.GetComponent<HealthComponent>().ReduceHp(1);
        }
        if (collision.gameObject.CompareTag("Player") && (gameObject.CompareTag("ProjectileEnemy")))
        {
            Destroy(gameObject);
            HealthPlayer.GetComponent<HealthComponent>().ReduceHp(1);
        }
    }
}
