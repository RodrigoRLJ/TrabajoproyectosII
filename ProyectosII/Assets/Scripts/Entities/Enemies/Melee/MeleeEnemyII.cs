using Entities.EnemyMelee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeEnemyControlerII : MonoBehaviour
{
    
    public Transform Player;
    public GameObject Terreno;
    private Rigidbody2D RigidBody2D;
    private Animator Animator;


    
    int distancia = 8;
    int velocidadPatrullando = 1;
    bool mirarIzquierda = false;
    int velocidadAtacando = 3;

    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.FindWithTag("Player").transform;
        this.Terreno = GameObject.FindWithTag("Terreno");
        RigidBody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();


    }
   
    void Update()
    {
        //transform.LookAt(Player);
        if (Vector2.Distance(transform.position, Player.position) <= distancia)
        {
            RigidBody2D.velocity = new Vector2(velocidadAtacando, RigidBody2D.velocity.y);

            if (Vector2.Distance(transform.position, Player.position) == 0)
            {
                //atacar
            }
        }
        else
        {
            patrulla();
        }
    }

    void patrulla()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.075f);
        if (hit.collider == null)
        {
            if (mirarIzquierda == true)
            {
                RigidBody2D.velocity = new Vector2(1, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                mirarIzquierda = false;
            }
            if (mirarIzquierda == false)
            {
                RigidBody2D.velocity = new Vector2(-1, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                mirarIzquierda = true;
            }
        }
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, 0.075f);
        if (hit2.collider == Terreno)
        {
            if (mirarIzquierda == true)
            {
                RigidBody2D.velocity = new Vector2(velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                mirarIzquierda = false;
            }
            if (mirarIzquierda == false)
            {
                RigidBody2D.velocity = new Vector2(-velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                mirarIzquierda = true;
            }
        }
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.left, 0.075f);
        if (hit3.collider == Terreno)
        {
            if (mirarIzquierda == true)
            {
                RigidBody2D.velocity = new Vector2(velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                mirarIzquierda = false;
            }
            if (mirarIzquierda == false)
            {
                RigidBody2D.velocity = new Vector2(-velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                mirarIzquierda = true;
            }
        }
        if (hit.collider != null && hit2.collider != Terreno && hit3.collider != Terreno)
        {
            if (mirarIzquierda == false)
            {
                RigidBody2D.velocity = new Vector2(velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                mirarIzquierda = false;
            }
            if (mirarIzquierda == true)
            {
                RigidBody2D.velocity = new Vector2(-velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                mirarIzquierda = true;
            }
        }
    }
}