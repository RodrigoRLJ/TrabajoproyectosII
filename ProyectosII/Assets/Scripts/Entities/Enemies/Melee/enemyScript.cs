using Entities.EnemyMelee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class MeleeEnemyControlerII : MonoBehaviour
{
    
    public Transform Player;
    public Collider2D obstaculo;
    private Rigidbody2D RigidBody2D;
    private Animator Animator;
    public Collision2D colision;


    int distancia = 8;
    int velocidadPatrullando = 1;
    bool mirarIzquierda = true;
    bool choque = false;
    int velocidadAtacando = 3;

    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.FindWithTag("Player").transform;
        //this.Terreno = GameObject.FindWithTag("Terreno");
        RigidBody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        

    }
   
    void Update()
    {
        //transform.LookAt(Player);
        Vector3 look = transform.InverseTransformPoint(Player.position);
        float angulo = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg-90;
        transform.Rotate(0, 0, angulo);
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

       RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
       Debug.Log("raycast down esta dando " + hit.collider);
        if (hit.collider == null)
        {
            if (mirarIzquierda == true)
            {
                RigidBody2D.velocity = new Vector2(velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                mirarIzquierda = false;
            }
            else{
                RigidBody2D.velocity = new Vector2(-velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                mirarIzquierda = true;
            }
        }
        //RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, 1f);
        //Debug.Log("raycast rifht esta dando " + hit2.collider);
        if (colision.gameObject.tag == "obstaculo")
        {
            choque = true;
            if (mirarIzquierda == true)
            {
                RigidBody2D.velocity = new Vector2(velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                mirarIzquierda = false;
            }else
            {
                RigidBody2D.velocity = new Vector2(-velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                mirarIzquierda = true;
            }
        }
        else
        {
            choque = false;
        }
        //RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.left, 1f);
        //Debug.Log("raycast left esta dando " + hit3.collider);
        //if (hit3.collider == Terreno)
        //{
        //    if (mirarIzquierda == true)
        //    {
        //        RigidBody2D.velocity = new Vector2(velocidadPatrullando, RigidBody2D.velocity.y);
        //        Animator.SetBool("Jumping", true);
        //        transform.rotation = Quaternion.Euler(0, 180, 0);
        //        mirarIzquierda = false;
        //    }
        //    else{
        //        RigidBody2D.velocity = new Vector2(-velocidadPatrullando, RigidBody2D.velocity.y);
        //        Animator.SetBool("Jumping", true);
        //        transform.rotation = Quaternion.Euler(0, 0, 0);
        //        mirarIzquierda = true;
        //    }
        //}
        if (hit.collider != null && choque ==false)
        {
            if (mirarIzquierda == false)
            {
                RigidBody2D.velocity = new Vector2(velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                mirarIzquierda = false;
            }
            else{
                RigidBody2D.velocity = new Vector2(-velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                mirarIzquierda = true;
            }
        }
    }
}