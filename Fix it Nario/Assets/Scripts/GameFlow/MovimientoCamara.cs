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
    public bool ShakeOnStart;
    // Start is called before the first frame update
    void Start()
    {
        if (ShakeOnStart)
        {
            Invoke("StartShake", 1);
        }
        else
        {
            Invoke("StartingMoving", 1);

        }
    }

    void StartingMoving()
    {
        onEndShake();
        DestroySomething();
        StartMoving();
    }

    void StartShake()
    {
        originalPos = this.transform.position;
        isShaking = true;
        Invoke("DestroySomething", 1.5f);
        Invoke("StopShake", 2.5f);
    }

    public GameObject weDestroy;
    void DestroySomething()
    {
        if (weDestroy != null)
        {
            Destroy(weDestroy);

        }
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
