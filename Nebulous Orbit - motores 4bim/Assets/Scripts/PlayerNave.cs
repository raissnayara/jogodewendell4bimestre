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

    private FimdeJogo fimjogo;

    private SpriteRenderer spriteRenderer;
    
    
    
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
        
        VerificarLimiteTela();
    }

    private void VerificarLimiteTela()
    {
        Vector2 posicaoAtual = this.transform.position;

        float metadeLargura = Largura / 2f;
        float metadeAltura = Altura / 2f;

        Camera camera = Camera.main;
        Vector2 LimiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero);
        Vector2 LimiteSuperiordireito = camera.ViewportToWorldPoint(Vector2.zero);

        float pontoReferenciaEsquerdo = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireito = posicaoAtual.x + metadeLargura;

        if (pontoReferenciaEsquerdo < LimiteInferiorEsquerdo.x)
        {
            this.transform.position = new Vector2(LimiteInferiorEsquerdo.x + metadeLargura,posicaoAtual.y);
        }
        else if(pontoReferenciaDireito < LimiteSuperiordireito.x)
        {
            this.transform.position = new Vector2(LimiteSuperiordireito.x - metadeLargura, posicaoAtual.y);
        }

        posicaoAtual = this.transform.position;

        float pontoRefernciaSuperior = posicaoAtual.y + metadeAltura;
        float pontoReferenciaInferior = posicaoAtual.y - metadeAltura;

        if (pontoRefernciaSuperior > LimiteSuperiordireito.y)
        {
            this.transform.position = new Vector2(posicaoAtual.x, LimiteSuperiordireito.y - metadeAltura);
            
        }
        
        else if (pontoReferenciaDireito < LimiteSuperiordireito.y)
        {
            this.transform.position = new Vector2(posicaoAtual.x, LimiteInferiorEsquerdo.y - metadeAltura);
        }

    }

    private float Largura
    {
        get
        {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.x;
        }
    }
    
    private float Altura
    {
        get
        {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.y;
        }
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
