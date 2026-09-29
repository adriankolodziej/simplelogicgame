using UnityEngine;

namespace Assets.Scripts.Mechanisms
{
	public class PressureButton : MonoBehaviour
	{
		[SerializeField] private GameObject connectedMechanism;
		[SerializeField] private float buttonSpeed;

		private Vector3 upPosition;		
		private Vector3 downPosition;
		private new Rigidbody rigidbody;
		public bool pushed;
		public bool stopped;
		private void Start()
		{
			rigidbody = GetComponent<Rigidbody>();
			upPosition = transform.localPosition;
			downPosition = new Vector3(upPosition.x, 0.55f, upPosition.z);
			pushed = false;
			stopped = true;
		}

		void FixedUpdate()
		{
			StabilizePosition();
		}

		void StabilizePosition()
		{
			if (pushed && !stopped)
			{
				if (transform.localPosition.y <= downPosition.y)
				{
					rigidbody.linearVelocity = Vector3.zero;
					stopped = true;
				}			
			}
			else if (!pushed && !stopped)
			{
				if (transform.localPosition.y >= upPosition.y)
				{
					rigidbody.linearVelocity = Vector3.zero;
					stopped = true;
				}
				else rigidbody.linearVelocity = new Vector3(0, buttonSpeed, 0);			
			}
			if(stopped)
				rigidbody.linearVelocity = Vector3.zero;
		}
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.transform.CompareTag("Player") || collision.collider.GetComponent<Rigidbody>())
			{
				connectedMechanism.GetComponentInChildren<BaseMechanism>().PerformAction();
				pushed = true;
				stopped = false;
			}
		}

		private void OnCollisionExit(Collision collision)
		{
			if (collision.collider.transform.CompareTag("Player") || collision.collider.GetComponent<Rigidbody>())
			{
				connectedMechanism.GetComponentInChildren<BaseMechanism>().PerformAction();
				pushed = false;
				stopped = false;
			}
		}
	}
}