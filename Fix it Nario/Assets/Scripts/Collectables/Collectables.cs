using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject view;
    public float speed;
    FixerManager fmanager;

    private void Start()
    {
        fmanager = GameObject.FindGameObjectWithTag("FixerManager").GetComponent<FixerManager>();
    }


    private void Update()
    {
        view.transform.Rotate(Vector3.up * speed * Time.deltaTime);        
    }

    private const int PLAYER_LAYER = 8;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == PLAYER_LAYER)
        {
            fmanager.CreateResource();
            Destroy(this.gameObject);
        }


    }
}
