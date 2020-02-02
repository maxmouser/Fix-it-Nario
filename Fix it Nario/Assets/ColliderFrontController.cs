using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFrontController : MonoBehaviour
{
	public MovimientoPlayer1 player;
	void Start()
    {
		player = FindObjectOfType<MovimientoPlayer1>();

	}

	void OnTriggerEnter(Collider other)
	{
		print("entro al trigger de back front");
		if (other.gameObject.layer == 12)//El layer 12 es el empuje front 
		{ 
			player.colisionEmpujeFront = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 12)
		{
			player.collisionEmpujeBack = false;

		}
	}

}
