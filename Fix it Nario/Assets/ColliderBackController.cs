using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBackController : MonoBehaviour
{
	public MovimientoPlayer1 player;
	// Start is called before the first frame update
	void Start()
	{
		player = FindObjectOfType<MovimientoPlayer1>();

	}

	void OnTriggerEnter(Collider other)
	{
		print("entro al trigger de back empuje");
		if (other.gameObject.layer == 10)//El layer 10 es el empuje back de la camara
		{ 
			player.collisionEmpujeBack = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 10)
		{
			player.collisionEmpujeBack = false;

		}
	}
}
