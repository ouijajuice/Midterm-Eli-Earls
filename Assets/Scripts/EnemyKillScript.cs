using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKillScript : MonoBehaviour
{
    public string incomingTag = "Projectile";

    private void OnCollisionEnter(Collision other) {
                     if (other.gameObject.CompareTag("Enemy")){
                                Destroy(other.gameObject); // this destroys the enemy
                                Destroy(gameObject); // this destroys the bullet
                     }
              }
}

