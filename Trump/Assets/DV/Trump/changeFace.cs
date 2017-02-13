using UnityEngine;
using System.Collections;

public class changeFace : MonoBehaviour
{
    public Texture[] textures;
    public float changeInterval = 0.33F;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (textures.Length == 0)
            return;
  
        int index = Mathf.FloorToInt(Time.time / changeInterval);
        index = index % textures.Length;
        if(Input.GetMouseButtonDown(0))
        rend.material.mainTexture = textures[index];
    }
}