using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FimJogo : MonoBehaviour
{


    public Text textoPontuacao;
   
    public void Exibir()
    {
        this.gameObject.SetActive(true);
        this.textoPontuacao.text = (ControladorPontuaçao.Pontuacao + "x");
    }

    public void TentarNovamente()
    {
        SceneManager.LoadScene("Fase01");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
