using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D CC;
    private bool OnGround = false;

    [SerializeField] private InputActionReference Left, Right, Up, Shoot;
    [SerializeField] private GameObject Projectile;

    void Start()
    {
        CC = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Left.action.inProgress)
        {
            CC.velocity = new Vector2(-10, CC.velocity.y);
        }
        if (Right.action.inProgress)
        {
            CC.velocity = new Vector2(10, CC.velocity.y);
        }
        if (OnGround == true && Up.action.inProgress)
        { 
            CC.velocity = new Vector2(CC.velocity.x, 20);
        }
        if (Shoot.action.inProgress)
        {
            GameObject newproj = Instantiate(Projectile);
        }
        CC.velocity -= new Vector2(0.5f * CC.velocity.normalized.x, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
    }
}