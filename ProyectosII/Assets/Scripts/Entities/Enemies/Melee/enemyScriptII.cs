
using Entities.Player;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class MeleeEnemyControlerIII : MonoBehaviour
{

    public Transform Player;
    public Collider2D obstaculo;
    private Rigidbody2D RigidBody2D;
    private Animator Animator;



    int distancia = 3;
    int velocidadPatrullando = 2;
    bool mirarIzquierda = true;
    bool choque = false;
    int velocidadAtacando = 3;

    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.FindWithTag("Player").transform;

        RigidBody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();


    }

    void Update()
    {
        ////esto hace que si el enmigo esta de frente ataca pero si esta de espaldas huye
        //Vector3 look = transform.InverseTransformPoint(Player.position);
        //float angulo = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
        //transform.Rotate(0, 0, angulo);


        if (Vector2.Distance(transform.position, Player.position) <= distancia)
        {



            //RigidBody2D.velocity = new Vector2(velocidadAtacando, RigidBody2D.velocity.y);


        }
        else
        {
            patrulla();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //acesso a componente PlayerController y su metodo PlayerChangeHealy 
            other.gameObject.GetComponent<PlayerController>().PlayerChangeHealth(-50);

        }
        if (other.gameObject.CompareTag("obstaculo") || other.gameObject.CompareTag("EnemigoMele"))
        {
            choque = true;
            if (mirarIzquierda == true)
            {
                RigidBody2D.velocity = new Vector2(velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                mirarIzquierda = false;
            }
            else
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
            else
            {
                RigidBody2D.velocity = new Vector2(-velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                mirarIzquierda = true;
            }
        }

        if (hit.collider != null && choque == false)
        {
            if (mirarIzquierda == false)
            {
                RigidBody2D.velocity = new Vector2(velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                mirarIzquierda = false;
            }
            else
            {
                RigidBody2D.velocity = new Vector2(-velocidadPatrullando, RigidBody2D.velocity.y);
                Animator.SetBool("Jumping", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                mirarIzquierda = true;
            }
        }
    }
}