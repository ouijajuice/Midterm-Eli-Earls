using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D rigibody;

    public float speed;

    public Vector2 minBoundary;
    public Vector2 maxBoundary;


    // Update is called once per frame
    void Update()
    {

        float xMov;

        xMov = Input.GetAxisRaw("Horizontal");

        Vector2 newPosition = rigibody.position + new Vector2(xMov * speed * Time.deltaTime, 0);

        newPosition.x = Mathf.Clamp(newPosition.x, minBoundary.x, maxBoundary.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBoundary.y, maxBoundary.y);

        rigibody.MovePosition(newPosition);

    }
}
