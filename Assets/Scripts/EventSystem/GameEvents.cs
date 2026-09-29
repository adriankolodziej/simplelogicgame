using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
	public static GameEvents current;
	void Awake()
	{
		current = this;
	}

	public event Action onDeathTriggerEnter;
	public void DeathTriggerEnter()
	{
		if (onDeathTriggerEnter != null)
		{
			onDeathTriggerEnter();
		}
	}

	public event Action onFinishZoneEnter;
	public void FinishZoneEnter()
	{
		if (onFinishZoneEnter != null)
		{
			onFinishZoneEnter();
		}
	}

	public event Action<int> onCubeDeathTriggerEnter;
	public void CubeDeathTriggerEnter(int id)
	{
		if (onCubeDeathTriggerEnter != null)
		{
			onCubeDeathTriggerEnter(id);
		}
	}
}
