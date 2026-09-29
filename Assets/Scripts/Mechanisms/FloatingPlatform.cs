using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Mechanisms
{
	public class FloatingPlatform : BaseMechanism
	{
		[SerializeField] private float floatingSpeed;
		[SerializeField] Transform start;
		[SerializeField] Transform finish;
		[SerializeField] private int direction = -1;

		private new Rigidbody rigidbody;
		private Vector3 destination;
		private Vector3 startingPosition;


		private bool wait = false;
		private float startTime;
		private float journeyLength;

		RigidbodyConstraints originalConstraints;
		void Start()
		{
			rigidbody = (Rigidbody)GetComponent(typeof(Rigidbody));
			originalConstraints = rigidbody.constraints;

			destination = start.position;
			startingPosition = finish.position;

			startTime = Time.time;
			journeyLength = Vector3.Distance(startingPosition, destination);
		}

		void FixedUpdate()
		{
			Move();
		}
		public override void PerformAction()
		{
			direction *= -1;
			startingPosition = transform.position;
			if (direction == 1)
				destination = finish.position;
			else if (direction == -1)
				destination = start.position;
			startTime = Time.time;
			journeyLength = Vector3.Distance(startingPosition, destination);
			rigidbody.constraints = originalConstraints;
			wait = false;

		}

		void Move()
		{
			if (!wait)
			{
				if (Vector3.Distance(transform.position, destination) > 0.05f)
				{
					float distCovered = (Time.time - startTime) * floatingSpeed;

					float fractionOfJourney = distCovered / journeyLength;

					transform.position = Vector3.Lerp(startingPosition, destination, fractionOfJourney);
				}
				else
				{
					wait = true;
					rigidbody.constraints = RigidbodyConstraints.FreezeAll;
				}
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<CharacterController>())
				StartCoroutine(ConnectTheCollider(other));
			if (other.gameObject.layer == 9)
				other.transform.SetParent(transform);
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.GetComponent<CharacterController>())
				StartCoroutine(FreeTheCollider(other));
			if(other.gameObject.layer == 9)
				other.transform.SetParent(null);
		}

		IEnumerator FreeTheCollider(Collider collider)
		{
			yield return new WaitForSeconds(0.1f);
			collider.transform.SetParent(null);
		}

		IEnumerator ConnectTheCollider(Collider collider)
		{
			yield return new WaitForSeconds(0.1f);
			collider.transform.SetParent(transform);
		}
	}
}