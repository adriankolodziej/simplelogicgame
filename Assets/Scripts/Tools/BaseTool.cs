using UnityEngine;

namespace Assets.Scripts.Tools
{
	public abstract class BaseTool : MonoBehaviour
	{
		[SerializeField] public float range = 2f;
		void Update()
		{
			Use();	
		}
		abstract public void Use();
	}
}