using UnityEngine;

public class LevelFinishZone : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<CharacterController>())
		{
			GameEvents.current.FinishZoneEnter();
		}
	}
}
