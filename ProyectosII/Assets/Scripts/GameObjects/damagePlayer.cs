using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Player;
public class damagePlayer : MonoBehaviour
{
    [SerializeField] private GameObject t;
    private void OnTriggerStay2D(Collider2D other) {
         if (other.CompareTag("Player")) {
             other.GetComponent<PlayerController>().PlayerChangeHealth(-10);
             other.GetComponent<PlayerController>().RelocatePlayer(t.transform);
         }
     }

}
