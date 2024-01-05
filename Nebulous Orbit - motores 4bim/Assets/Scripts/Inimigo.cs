using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inimigo : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    
    
    public Rigidbody2D rigid;

    
    
    public float VelocidadeMinima;
    public float VelocidadeMaxima;
    public float VelocidadeY;

    public ParticleSystem particulaExplosaoprefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 posicaoAtual = this.transform.position;
        float metadeLargura = Largura / 2f;

        float pontoReferenciaEsquerda = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireita = posicaoAtual.x + metadeLargura;

        Camera camera = Camera.main;
        Vector2 LimiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero);
        Vector2 LimiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one);

        if (pontoReferenciaEsquerda < LimiteInferiorEsquerdo.x)
        {
            float PosicaoX = LimiteInferiorEsquerdo.x - metadeLargura;
            this.transform.position = new Vector2(PosicaoX, posicaoAtual.y);
        }
        
        else if (pontoReferenciaDireita > LimiteSuperiorDireito.x)
        {
            float posicaoX = LimiteSuperiorDireito.x - metadeLargura;
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y);
        }
        
        
        this.VelocidadeY = Random.Range(this.VelocidadeMinima, this.VelocidadeMaxima);
    }

    // Update is called once per frame
    void Update()
    {
        this.rigid.velocity = new Vector2(0, -this.VelocidadeY);
        
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        if (posicaoNaCamera.y < 0)
        {
            //inimigo saiu da area da camera
            PlayerNave nave = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerNave>();
            nave.Vida--;
            Destruir(false);
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

    public void Destruir(bool derrotado)
    {
        if (derrotado)
        {
            ControladorPontuaçao.Pontuacao++;
        }

        ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoprefab, this.transform.position, quaternion.identity);
        Destroy(particulaExplosao.gameObject, 1f); // destroi a particula apos 1 segundo
        
        Destroy(this.gameObject);
    }
}
