using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVida : MonoBehaviour
{
    public GameObject[] BarrasVermelhas;
    // Start is called before the first frame update


    public void Exibirvida(int vidas)
    {
        for (int i = 0; i < this.BarrasVermelhas.Length; i++)
        {
            if (i < vidas)
            {
                this.BarrasVermelhas[i].SetActive(false);
            }

            else
            {
                this.BarrasVermelhas[i].SetActive(true);
            }
        }
    }
}
