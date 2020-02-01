using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlatformerGO;
    public GameObject FixerGO;

    bool isGameInPause = false;

    private MovimientoPlayer1 playerM;
    public FixerManager fixerM;

    // Start is called before the first frame update
    void Start()
    {
        
        //Instantiate Platformer and Fixer
        //fixerM = Instantiate(FixerGO, Vector3.zero, Quaternion.identity).GetComponent<FixerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameInPause)
        {
            fixerM.UpdateFixerManager();
        }
    }
}
