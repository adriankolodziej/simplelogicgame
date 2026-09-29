using UnityEngine;

namespace Assets.Scripts.Mechanisms
{
	public class Door : BaseMechanism
	{
		[SerializeField] private Rigidbody leftDoor;
		[SerializeField] private Rigidbody rightDoor;
		[SerializeField] private float velocity;

		[SerializeField] private bool wait;

		[SerializeField] private int direction = -1;
		void Start()
		{
			wait = true;
		}

		void Update()
		{
			Slide();
		}
		public override void PerformAction()
		{
			direction *= -1;
			wait = false;
		}

		void Slide()
		{
			if (!wait)
			{
				ChangeVelocity(leftDoor, direction);
				ChangeVelocity(rightDoor, -direction);
			}
		}

		void ChangeVelocity(Rigidbody rigidbody, int dir)
		{
			var localVelocity = transform.InverseTransformDirection(rigidbody.linearVelocity);
			localVelocity.x = dir * velocity;
			rigidbody.linearVelocity = transform.TransformDirection(localVelocity);
		}
	}
}