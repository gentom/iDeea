using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{

	[SerializeField] Client client;
	BubbleGenerator bubbleGenerator;
	private Vector3 pos;

	// Use this for initialization
	void Start ()
	{
		bubbleGenerator = GetComponent<BubbleGenerator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void SendWord (string word, Vector3 p)
	{
		pos = p;
		client.GetWords (word);
	}

	// From InputField
	public void DefineWord (string[] words)
	{
		// ここでClientにwordを渡す


		bubbleGenerator.GenerateBubbles (words, Vector3.zero);
	}


	public void DefineWord (string word, Vector3 pos)
	{
		// ここでClientにwordを渡す


		bubbleGenerator.GenerateBubbles (client.GetWords (), pos);
	}

}
