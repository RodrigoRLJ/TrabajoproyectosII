using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D RigidBody2D;
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       
        if (Input.GetKey("d")){
            RigidBody2D.velocity = new Vector2(1, RigidBody2D.velocity.y);
            Animator.SetBool("Running", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(Input.GetKey("a"))
        {
            RigidBody2D.velocity = new Vector2(-1, RigidBody2D.velocity.y);
            Animator.SetBool("Running", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            Animator.SetBool("Running", false);
        }

        Saltar();
    }

    void Saltar()//no furula
    {
        bool permisoSaltar = false;
        if (gameObject.transform.position.y <= 0)
        {
            permisoSaltar = true;
        }
        if (Input.GetKey("w") && gameObject.transform.position.y < 1f && permisoSaltar)
        {
            gameObject.transform.Translate(0, 1f * Time.deltaTime, 0);
            
        }
        else
        {
            permisoSaltar = false;
            if (gameObject.transform.position.y > 0) {
                gameObject.transform.Translate(0, -1f * Time.deltaTime, 0);
            }
            
        }
    }
}
