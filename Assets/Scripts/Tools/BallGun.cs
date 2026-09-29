using UnityEngine;

namespace Assets.Scripts.Tools
{
	public class BallGun : BaseTool
	{
		[SerializeField] private Transform bulletPrefab;
		[SerializeField] private Transform shootingPoint;
		[SerializeField] private float shootForce;
		[SerializeField] private float shootDelay = 0.5f;
		[SerializeField] private Transform playerBody;

		private float timer;
		public override void Use()
		{
			timer += Time.deltaTime;

			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				if (timer >= shootDelay)
				{
					RaycastHit hit;
				
					if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, range))
					{
						Transform t = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
						t.LookAt(hit.point);
						t.GetComponent<Rigidbody>().AddForce(t.forward * shootForce);
					}
					timer = 0;
				}
			}
		}
	}
}