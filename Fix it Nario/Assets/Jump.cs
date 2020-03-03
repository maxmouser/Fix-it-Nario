using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DoShit", 1, 3);
    }

    public float forceJump;
    public ForceMode ForceMode;

    void DoShit()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.up * forceJump, ForceMode);
    }
}
