using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
    public Inimigo inimigoOrignal;
    private float tempoDeCorrido;
    // Start is called before the first frame update
    void Start()
    {
        this.tempoDeCorrido = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.tempoDeCorrido += Time.deltaTime;
        if(this.tempoDeCorrido >= 1f)
        {
            this.tempoDeCorrido = 0;

            Vector2 PosicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 Posicaominima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            float PosicaoX = Random.Range(Posicaominima.x, PosicaoMaxima.x);
            Vector2 PosicaoInimigo = new Vector2(PosicaoX, PosicaoMaxima.y);
            
            Instantiate(this.inimigoOrignal,PosicaoInimigo, Quaternion.identity);
        }
    }
}
