using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D CC;
    private bool OnGround = false;
    private Vector2 _mousepos = Vector2.zero;

    [SerializeField] private InputActionReference Left, Right, Up, Shoot ,mousePos;
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
            CC.velocity = new Vector2(-5, CC.velocity.y);
        }
        if (Right.action.inProgress)
        {
            CC.velocity = new Vector2(5, CC.velocity.y);
        }
        if (OnGround == true && Up.action.inProgress)
        { 
            CC.velocity = new Vector2(CC.velocity.x, 15);
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

    public void GetMousePos(InputAction.CallbackContext context) 
    { 
        _mousepos = context.ReadValue<Vector2>();
        _mousepos = Camera.main.ScreenToWorldPoint(_mousepos);
    }

    public void ShootFunc (InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Vector2 PlayerPos = (Vector2)GetComponent<Transform>().position;
            Vector2 ShootVector = _mousepos - PlayerPos;
            GameObject NewProjectile;
            if (_mousepos.x >= PlayerPos.x) { NewProjectile = Instantiate(Projectile, transform.position + new Vector3 (1,0,0), transform.rotation); }
            else { NewProjectile = Instantiate(Projectile, transform.position + new Vector3(-1, 0, 0), transform.rotation); }

            NewProjectile.GetComponent<banana>().SetAngle(ShootVector.normalized, 25);
        }
    }
} 