using UnityEngine;

public class Cube : MonoBehaviour
{
	[SerializeField] private int id;
	private bool isColliding;
	void Start()
	{
		GameEvents.current.onCubeDeathTriggerEnter += Destroy;
	}

	void Destroy(int id)
	{
		if (this.id == id)
			Destroy(gameObject);
	}

	private void OnDestroy()
	{
		GameEvents.current.onCubeDeathTriggerEnter -= Destroy;
	}

	public int GetId()
	{
		return id;
	}

	public void SetId(int id)
	{
		this.id = id;
	}

	public bool IsColliding()
	{
		return isColliding;
	}
	private void OnCollisionEnter(Collision collision)
	{
		isColliding = true;
	}

	private void OnCollisionExit(Collision collision)
	{
		isColliding = false;
	}
}
