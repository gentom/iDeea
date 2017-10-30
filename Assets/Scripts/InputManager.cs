using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
	[SerializeField] InputField inputField;
	[SerializeField] BubbleController bubbleController;

	public void InputLogger ()
	{
		bubbleController.SendWord (inputField.text, Vector3.zero);
	}
}
