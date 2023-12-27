using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rig;

    public float velocidadeLaser;
    // Start is called before the first frame update
    void Start()
    {
        this.rig.velocity = new Vector2(0, this.velocidadeLaser);
    }

    private void Update()
    {
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        // saiu da tela na parte superior
        if (posicaoNaCamera.y > 1)
        {
            // destrói o proprio laser
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("inimigo"))
        {
            Inimigo inimigo = collider.GetComponent<Inimigo>();
            inimigo.Destruir(true);
            
            Destroy(this.gameObject);
        }
    }
    
}
