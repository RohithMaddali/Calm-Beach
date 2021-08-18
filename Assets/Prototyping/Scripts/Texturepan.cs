using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texturepan : MonoBehaviour
{
    public float Scrollx;
    public float Scrolly;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * Scrollx;
        float offsetY = Time.time * Scrolly;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
