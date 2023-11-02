using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScrollingScript : MonoBehaviour
{
    // a reference to the mesh for this object, where the material is
    public MeshRenderer textureMesh;
    //the rate at which the tiling will change every second
    public Vector2 tilingSpeed;
    //a private reference to the material we're offsetting, so we dont have to get it every frame
    private Material mat;

    private void Start()
    {
        mat = textureMesh.material;
    }

    // Update is called once per frame
    void Update()
    {
        //set the main texture and normal map offset to be its current value
        //+ the tiling speed normalized, that way we can continuously increase it
        mat.SetTextureOffset("_MainTex",
            mat.GetTextureOffset("_MainTex") + tilingSpeed * Time.deltaTime);
    }
}
