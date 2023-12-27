using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{

    public Text TextoPontuaçao;

    public BarraVida BarraVida;

    private PlayerNave Nave;
    // Start is called before the first frame update
    void Start()
    {
        this.Nave = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerNave>();
    }

    // Update is called once per frame
    void Update()
    {
        this.BarraVida.Exibirvida(this.Nave.Vida);
        this.TextoPontuaçao.text = (ControladorPontuaçao.Pontuacao + "x");
    }
}
