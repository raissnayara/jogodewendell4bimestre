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

    public Transform[] posicoesArmas;
    private Transform ArmaAtual;

    private int vidas;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.IntervaloTiro = 0;
        this.ArmaAtual = this.posicoesArmas[0];
        ControladorPontuaçao.Pontuacao = 0;
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("inimigo"))
        {
            Vida--;
            Inimigo inimigo = collider.GetComponent<Inimigo>();
            inimigo.Destruir(false);
        }
    }

    public int Vida
    {
        get { return this.vidas;}
        set
        {
            this.vidas = value;
            if (this.vidas < 0)
            {
                this.vidas = 0;
            }
        }
    }

    private void Atirar()
    {
        Instantiate(this.laserPrefab, this.ArmaAtual.position, quaternion.identity);
        if (this.ArmaAtual == this.posicoesArmas[0])
        {
            this.ArmaAtual = this.posicoesArmas[1];
            
        }

        else
        {
            this.ArmaAtual = this.posicoesArmas[0];
        }
    }

    //public void OnTriggerEnter2D(Collider2D collider)
    //{
        //if (collider.CompareTag("inimigo"))
        //{
            //Destroy(collider.gameObject);
            
            //Destroy(this.gameObject);
        //}
    //}
}
