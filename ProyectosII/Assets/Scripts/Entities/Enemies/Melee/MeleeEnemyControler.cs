//using Entities.EnemyMelee;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class MeleeEnemyControler : MonoBehaviour
//{
//    [SerializeField] public EnemyMeleeStats stats;
//    public List<Transform> coordenada;
//    public Transform Player;
//    private Rigidbody2D RigidBody2D;

//    int siguienteCoordenada = 0;
//    int cambioCoordenada = 1;
//    int distancia = 8;
//    int velocidadpatrullando = 1;

//    int velocidadAtacando = 3;

//    // Start is called before the first frame update
//    void Start()
//    {
//        this.Player = GameObject.FindWithTag("Player").transform;
//        RigidBody2D = GetComponent<Rigidbody2D>();
       
//    }
//    //void Init()
//    //{
//    //GameObject waypoints = new GameObject("waypoints");

//    //
//    //}
//    // Update is called once per frame
//    void Update()
//    {
//        transform.LookAt(Player);
//        if (Vector3.Distance(transform.position, Player.position) >= distancia)
//        {
//            RigidBody2D.velocity = new Vector2(velocidadAtacando, RigidBody2D.velocity.y);

//            if (Vector3.Distance(transform.position, Player.position) == 0)
//            {
//                //atacar
//            }
//        }
//        else
//        {
//            patrulla();
//        }
//    }

//    void patrulla()
//    {
//        Transform objetivo = coordenada[siguienteCoordenada];
//        if (objetivo.transform.position.x > transform.position.x)
//        {
//            transform.localScale = new Vector3(-1, 1, 1);
//        }
//        else
//        {
//            transform.localScale = new Vector3(1, 1, 1);
//        }

//        transform.position =
//            Vector2.MoveTowards(transform.position, objetivo.position, velocidadpatrullando * Time.deltaTime);
//        if (Vector3.Distance(transform.position, objetivo.position) < 1f)
//        {
//            if (siguienteCoordenada == 1)
//            {
//                cambioCoordenada = -1;
//            }

//            if (siguienteCoordenada == 0)
//            {
//                cambioCoordenada = 1;
//            }

//            siguienteCoordenada += cambioCoordenada;
//        }
//    }
//}