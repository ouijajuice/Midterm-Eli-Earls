using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    public GameObject projectile;
    public string shootButton;
    public Transform firePoint;
    public float shootCooldown;
    public float booletSpeed;
    float shootCooldownTimer;
    // Update is called once per frame
    void Update()
    {
        shootCooldownTimer += Time.deltaTime;

        if (Input.GetButtonDown(shootButton)
            && shootCooldownTimer >= shootCooldown)
        {
            shoot();
        }
    }

    void shoot()
    {
        GameObject newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * booletSpeed;
        shootCooldownTimer = 0;
    }
}
