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
		if (string.IsNullOrEmpty (word)) {
			Debug.Log ("You can't send Null or Empty word");
		} else {
			bubbleController.SendWord (word, Vector3.zero); //本番
		}
	}
}
