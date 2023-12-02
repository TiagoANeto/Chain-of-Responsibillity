using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(5);
        }
    }
}
