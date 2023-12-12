using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNave : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float velocidadeX = (horizontal * this.speed);
        float velocidadeY = (vertical * this.speed);
        
        
        
        this.rig.velocity = new Vector2(velocidadeX,velocidadeY);
    }
}
