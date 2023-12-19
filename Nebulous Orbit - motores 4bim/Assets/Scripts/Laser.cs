using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rig;

    public float velocidadeLaser;
    // Start is called before the first frame update
    void Start()
    {
        this.rig.velocity = new Vector2(0, this.velocidadeLaser);
    }

    // Update is called once per frame
    
}
