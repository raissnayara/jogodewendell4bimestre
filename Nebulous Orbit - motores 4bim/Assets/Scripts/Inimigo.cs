using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inimigo : MonoBehaviour
{
    public Rigidbody2D rigid;

    public float VelocidadeMinima;

    public float VelocidadeMaxima;

    public float VelocidadeY;

    public ParticleSystem particulaExplosaoprefab;
    // Start is called before the first frame update
    void Start()
    {
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
            PlayerNave nave = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerNave>();
            nave.Vida--;
            Destruir(false);
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
