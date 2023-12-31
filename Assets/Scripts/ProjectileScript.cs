using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private float lifetimeCounter = 0;

    public Transform powerupPrefab;
    public float powerupSpawnChance = 0.2f;

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (Random.value <= powerupSpawnChance)
            {
                Instantiate(powerupPrefab, other.transform.position, Quaternion.identity);
            }
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
