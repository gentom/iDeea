using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
	[SerializeField] InputField inputField;
	[SerializeField] BubbleCreator bubbleCreator;

	public void InputLogger()
	{
		bubbleCreator.InputText (inputField.text);
	}
}
