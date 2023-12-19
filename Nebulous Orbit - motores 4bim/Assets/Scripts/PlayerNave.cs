using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerNave : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed;

    public Laser laserPrefab;
    private float IntervaloTiro;
    public float TempoEsperaTiro;
    
    // Start is called before the first frame update
    void Start()
    {
        this.IntervaloTiro = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.IntervaloTiro += Time.deltaTime;
        if (this.IntervaloTiro >= this.TempoEsperaTiro)
        {
            this.IntervaloTiro = 0;
            Atirar();
        }
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float velocidadeX = (horizontal * this.speed);
        float velocidadeY = (vertical * this.speed);
        
        
        
        this.rig.velocity = new Vector2(velocidadeX,velocidadeY);
    }

    private void Atirar()
    {
        Instantiate(this.laserPrefab, this.transform.position, quaternion.identity);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("inimigo"))
        {
            Destroy(collider.gameObject);
            
            Destroy(this.gameObject);
        }
    }
}
