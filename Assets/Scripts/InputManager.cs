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
		string word = inputField.text;
		bubbleController.SendWord (word, Vector3.zero); //本番
		//bubbleController.DefineWord (word); //For Demo
	}
}
