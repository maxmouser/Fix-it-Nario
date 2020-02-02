using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovimientoCamara : MonoBehaviour
{
    public float velocidadCamara=0.1f;

    Vector3 originalPos;
    private bool isShaking;
    private bool moving;
    private float shakeAmount = 0.7f;

    public Action onEndShake;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = this.transform.position;
        Invoke("StartShake", 1);
    }

    void StartShake()
    {
        isShaking = true;
        Invoke("StopShake", 2.5f);
    }

    void StopShake()
    {
        isShaking = false;
        this.transform.localPosition = originalPos;
        onEndShake();
        Invoke("StartMoving", 1);
    }

    void StartMoving()
    {
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            Shaking();
        }
        else if(moving)
        {

            Moving();
        }


    }

    private void Shaking()
    {
        this.transform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * shakeAmount;
    }

    private void Moving()
    {
        this.transform.position = new Vector3(transform.position.x + velocidadCamara * Time.deltaTime, transform.position.y, transform.position.z);
        //velocidadCamara = Math.Log(Time.);
    }
}
