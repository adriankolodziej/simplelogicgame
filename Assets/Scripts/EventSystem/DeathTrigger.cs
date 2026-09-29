using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<CharacterController>())
		{
			GameEvents.current.DeathTriggerEnter();
		}
		else
		{
			Cube cube = other.GetComponent<Cube>();
			if (cube != null)
				GameEvents.current.CubeDeathTriggerEnter(cube.GetId());
		}
	}
}
