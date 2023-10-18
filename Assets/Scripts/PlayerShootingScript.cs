using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    public Transform projectile;
    public string shootButton;
    public float shootCooldown;
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
        Instantiate(projectile, transform.position, Quaternion.identity);
        shootCooldownTimer = 0;
    }
}
