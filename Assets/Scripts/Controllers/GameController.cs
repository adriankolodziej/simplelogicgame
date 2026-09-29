using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image endingScreen;
    void Start()
    {
        GameEvents.current.onDeathTriggerEnter += RestartCurrentLevel;
        GameEvents.current.onFinishZoneEnter += FinishCurrentLevel;
    }

    void RestartCurrentLevel()
	{
        StartCoroutine(RestartTheLevel());
	}
    IEnumerator RestartTheLevel()
	{
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    void FinishCurrentLevel()
	{
        endingScreen.gameObject.SetActive(true);
        StartCoroutine(FinishTheLevel());
	}

    IEnumerator FinishTheLevel()
    {
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
    }

	private void OnDestroy()
	{
        GameEvents.current.onDeathTriggerEnter -= RestartCurrentLevel;
        GameEvents.current.onFinishZoneEnter -= FinishCurrentLevel;
    }
}
