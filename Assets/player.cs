using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D CC;
    private bool OnGround = false;
    private Vector2 MousePos = Vector2.zero;
    public float MouseAngle;
    private bool HoldMouse = false;
    public bool TimerOver = false;

    public float force;

    [SerializeField] private InputActionReference Left, Right, Up, Shoot ,mousePos;
    [SerializeField] private GameObject Projectile;
    public GameObject GameEvent;


    void Start()
    {
        CC = GetComponent<Rigidbody2D>();
        GameEvent = GameObject.Find("GameEvent");
    }

    // Update is called once per frame
    void Update()
    {
        if (Left.action.inProgress && GameEvent.GetComponent<GameEventScript>().PlayerTurn == true)
        {
            CC.velocity = new Vector2(-5, CC.velocity.y);
        }
        if (Right.action.inProgress && GameEvent.GetComponent<GameEventScript>().PlayerTurn == true)
        {
            CC.velocity = new Vector2(5, CC.velocity.y);
        }
        if (Up.action.inProgress && OnGround && GameEvent.GetComponent<GameEventScript>().PlayerTurn == true)
        { 
            CC.velocity = new Vector2(CC.velocity.x, 15);
        }
        CC.velocity -= new Vector2(0.5f * CC.velocity.normalized.x, 0);

        if (HoldMouse && GameEvent.GetComponent<GameEventScript>().PlayerTurn == true)
        {
            if (force < 25)
            {
                force += 12f * Time.deltaTime;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
    }

    public void GetMousePos(InputAction.CallbackContext context) 
    { 
        MousePos = context.ReadValue<Vector2>();
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);

        Vector2 PlayerPos = (Vector2)GetComponent<Transform>().position;
        MouseAngle = Mathf.Atan2(MousePos.y - PlayerPos.y, MousePos.x - PlayerPos.x);
        MouseAngle *= Mathf.Rad2Deg;
    }

    public void ShootFunc (InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            HoldMouse = true;
        }
        if (context.phase == InputActionPhase.Canceled && GameEvent.GetComponent<GameEventScript>().PlayerTurn == true)
        {
            HoldMouse = false;
            Vector2 PlayerPos = (Vector2)GetComponent<Transform>().position;
            Vector2 ShootVector = MousePos - PlayerPos;
            GameObject NewProjectile;
            NewProjectile = Instantiate(Projectile, transform.position, transform.rotation);
            NewProjectile.GetComponent<banana>().SetAngle(ShootVector.normalized, force);
            force = 0;
        }
    }
} 