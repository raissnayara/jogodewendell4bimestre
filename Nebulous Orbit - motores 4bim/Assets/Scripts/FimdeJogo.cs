using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;

public class FimdeJogo : MonoBehaviour
{

    public Text TextoPontuaçao;
    // Start is called before the first frame update



    public void Exibir()
    {
        this.gameObject.SetActive(true);
        this.TextoPontuaçao.text = (ControladorPontuaçao.Pontuacao + "x");
    }

    public void TentarNovamente()
    {
        
    }
}
