using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{

	public float velocidadCamara=0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //velocidadCamara = Math.Log(Time.);
       this.transform.position = new Vector3(transform.position.x + velocidadCamara * Time.deltaTime, transform.position.y, transform.position.z );


    }
}
