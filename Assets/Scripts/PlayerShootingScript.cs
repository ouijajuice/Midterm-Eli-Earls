using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    public Transform projectile;
    public string shootButton;
    public float shootCooldown;
    float shootCooldownTimer;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
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

    public void UpdateShootCooldown(float newCooldown)
    {
        shootCooldown = newCooldown;
    }

    void shoot()
    {
        audioSource.Play();
        Instantiate(projectile, transform.position, Quaternion.identity);
        shootCooldownTimer = 0;
    }
}
