using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	private int id;
	[SerializeField] Transform spawnPoint;
	[SerializeField] private GameObject cube;
	void Start()
	{
		GameEvents.current.onCubeDeathTriggerEnter += SpawnCube;	
	}

	void SpawnCube(int id)
	{
		if (this.id == id)
		{
			GameObject go = Instantiate(cube, spawnPoint.position, Quaternion.identity);
			go.GetComponent<Cube>().SetId(id);
		}
	}

	public void SetupDefaultState(int id)
	{
		this.id = id;
		GameObject go = Instantiate(cube, spawnPoint.position, Quaternion.identity);
		go.GetComponent<Cube>().SetId(id);
	}
}
