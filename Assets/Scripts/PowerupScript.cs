using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private float lifetimeCounter = 0;
    private float shootCooldown = 0.8f;
    private int powerUpCount = 2;
    // Update is called once per frame
    void Update()
    {
        MoveProjectile();

        lifetimeCounter += Time.deltaTime;

        if (lifetimeCounter > lifetime)
        {
            Destroy(gameObject);
        }
    }
    void MoveProjectile()
    {
        Vector3 newPos = transform.position;
        newPos += transform.up * speed * Time.deltaTime;
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("trigger func running");
        if (other.gameObject.CompareTag("Player"))
        {
            powerUpCount = powerUpCount + 1;
            PlayerShootingScript shootingScript = other.GetComponent<PlayerShootingScript>();

            shootCooldown -= 0.1f * powerUpCount;

            if (shootCooldown < 0.4f)
            {
                shootCooldown = 0.4f;
            }
            shootingScript.UpdateShootCooldown(shootCooldown);


            Destroy(gameObject);
            
        }
    }
}
