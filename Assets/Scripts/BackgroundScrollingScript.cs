using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollingScript : MonoBehaviour
{
    public float scrollingSpeed = 1.0f;

    void Update()
    {
        float offset = Time.time * scrollingSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset);
    }
}