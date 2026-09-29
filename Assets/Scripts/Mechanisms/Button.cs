using Assets.Scripts.Tools;
using UnityEngine;

namespace Assets.Scripts.Mechanisms
{
	public class Button : MonoBehaviour
	{
		[SerializeField] private GameObject[] connectedMechanisms;
		private void OnCollisionEnter(Collision collision)
		{
			if(collision.transform.GetComponent(typeof(Ball)))
			{
				foreach (GameObject go in connectedMechanisms)
				{
					go.GetComponentInChildren<BaseMechanism>().PerformAction();
				}
			}
		}
	}
}