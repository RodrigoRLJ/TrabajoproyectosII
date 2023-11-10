using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Player;
public class damagePlayer : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")) {
//            if(other.GetComponent<PlayerController>().PlayerChangeHealth(-10);

            //other.PlayerChangeHealth(-10);
  //          ((PlayerController)other.transform).PlayerChangeHealth(-10);
        }
    }
}
