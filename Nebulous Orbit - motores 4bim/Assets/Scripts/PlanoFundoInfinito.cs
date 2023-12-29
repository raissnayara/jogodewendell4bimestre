using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanoFundoInfinito : MonoBehaviour
{

    public Renderer renderer;
    public float velocidade;

    private Material material;
    private Vector2 offsetMaterial;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.material = this.renderer.material;
        this.offsetMaterial = this.material.GetTextureOffset("maintext");
    }

    // Update is called once per frame
    void Update()
    {
        this.offsetMaterial.y -= this.velocidade * Time.deltaTime;
        this.material.SetTextureOffset("maintext",this.offsetMaterial);
    }
}
