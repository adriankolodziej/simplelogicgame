using UnityEngine;

namespace Assets.Scripts.Tools
{
	public class ToolsController : MonoBehaviour
	{
		[SerializeField] private BaseTool[] tools;

		private KeyCode[] keyCodes =
		{
			KeyCode.Alpha1,
			KeyCode.Alpha2,
		};

		private int numberPressed = 0;

		void Update()
		{
			ToolSwitchKeys();
			ToolSwitchScroll();
		}

		void ToolSwitchKeys()
		{
			for (int i = 0; i < keyCodes.Length; i++)
			{
				if (Input.GetKeyDown(keyCodes[i]))
				{
					numberPressed = i;
					Debug.Log(numberPressed);
					ChooseWeapon(numberPressed);
				}
			}
		}

		void ToolSwitchScroll()
		{
			if (Input.GetAxis("Mouse ScrollWheel") > 0)
			{
				numberPressed++;
				if (numberPressed > keyCodes.Length - 1)
					numberPressed = 0;
				Debug.Log(numberPressed);
				ChooseWeapon(numberPressed);
			}
			else if (Input.GetAxis("Mouse ScrollWheel") < 0)
			{
				numberPressed--;
				if (numberPressed < 0)
					numberPressed = keyCodes.Length - 1;
				Debug.Log(numberPressed);
				ChooseWeapon(numberPressed);
			}
		}

		void ChooseWeapon(int chosenToolIndex)
		{
			for (int i = 0; i < tools.Length; i++)
			{
				if (chosenToolIndex == i)
					tools[i].gameObject.SetActive(true);
				else
					tools[i].gameObject.SetActive(false);
			}
		}
	}
}
