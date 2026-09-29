using UnityEngine;

namespace Assets.Scripts.Tools
{
	public class GravityGun : BaseTool
	{
		[SerializeField] private float lerpSpeed = 10f;
		[SerializeField] private LayerMask mask;
		[SerializeField] private float maxDifference = 1f;

		private Rigidbody heldItem;
		private Vector3 holdingRotation;
		private float xRotation;
		private float yRotation;
		private float zRotation;
		void Start()
		{
			heldItem = null;
		}

		public override void Use()
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				PickUpAnItem();
			}
			if (heldItem != null)
			{
				HoldItem();
			}
		}

		void PickUpAnItem()
		{
			if (heldItem == null)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, range, mask))
				{
					heldItem = (Rigidbody)hit.transform.GetComponent(typeof(Rigidbody));
				}
			}
			else
				DropItem();
		}

		void HoldItem()
		{
			Vector3 movePosition = Vector3.Lerp(heldItem.transform.position, Camera.main.transform.position + Camera.main.transform.forward * range, Time.deltaTime * lerpSpeed);
			heldItem.MovePosition(movePosition);

			xRotation = Camera.main.transform.eulerAngles.x;
			yRotation = Camera.main.transform.eulerAngles.y;
			zRotation = Camera.main.transform.eulerAngles.z;
			heldItem.transform.eulerAngles = holdingRotation + new Vector3(xRotation - Camera.main.transform.eulerAngles.x, yRotation, zRotation);
			heldItem.linearVelocity = Vector3.zero;
			heldItem.interpolation = RigidbodyInterpolation.Interpolate;
			heldItem.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

			if (heldItem.GetComponent<Cube>().IsColliding())
				if (Vector3.Distance(Camera.main.transform.position + Camera.main.transform.forward * range, heldItem.position) >= maxDifference)
					DropItem();
		}
		void DropItem()
		{
			if (heldItem != null)
			{
				heldItem.interpolation = RigidbodyInterpolation.None;
				heldItem.collisionDetectionMode = CollisionDetectionMode.Discrete;
				heldItem.linearVelocity = Vector3.zero;
				heldItem = null;
			}
		}

		private void OnDisable()
		{
			DropItem();
		}
	}
}