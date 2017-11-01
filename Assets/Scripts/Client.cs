using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Client : MonoBehaviour
{
	[SerializeField] BubbleController bubbleController;
	string URL = "http://127.0.0.1:8000/";

	// Test
	string[] words = {
		"a",
		"b",
		"c",
		"d",
		"e",
		"f",
		"g",
		"h",
		"i",
		"j",
	};

	string[] resultList;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}


	public void GetWords (string word, Vector3 pos)
	{
		StartCoroutine (Post (word, pos));
	}

	private IEnumerator Post (string word, Vector3 pos)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("word", word);
		UnityWebRequest request = UnityWebRequest.Post (URL, form);

		// リクエスト送信
		yield return request.Send ();

		if (request.isNetworkError) {
			Debug.Log ("Error:" + request.error);
		} else {
			if (request.responseCode == 200) {
				// Get Data from Python Server
				string w = request.downloadHandler.text;
				Debug.Log (w);
				char[] removeChars = new char[] { '[', ']', '"', ' ' };
				foreach (char c in removeChars) {
					w = w.Replace (c.ToString (), "");
				}
				resultList = w.Split (',');
				for (int i = 0; i < 10; i++) {
					Debug.Log (resultList [i]);
				}
				bubbleController.DefineWord (resultList, pos);
				Debug.Log ("Success :D");
			} else {
				Debug.Log ("Failed ;( :" + request.responseCode);
			}
		}
	}

}
