using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Rigidbody2D rigid;

    public float VelocidadeMinima;

    public float VelocidadeMaxima;

    public float VelocidadeY;
    // Start is called before the first frame update
    void Start()
    {
        this.VelocidadeY = Random.Range(this.VelocidadeMinima, this.VelocidadeMaxima);
    }

    // Update is called once per frame
    void Update()
    {
        this.rigid.velocity = new Vector2(0, -this.VelocidadeY);
    }

    public void Destruir(bool derrotado)
    {
        if (derrotado)
        {
            ControladorPontuaçao.Pontuacao++;
        }
        
        Destroy(this.gameObject);
    }
}
