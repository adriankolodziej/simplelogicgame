using UnityEngine;

namespace Assets.Scripts.Tools
{
	public class Ball : MonoBehaviour
	{
		[SerializeField] private float lifeTime = 5f;

		private float timer;
		
		void Update()
		{
			timer += Time.deltaTime;
			if (timer >= lifeTime)
				Destroy(gameObject);
		}
	}
}