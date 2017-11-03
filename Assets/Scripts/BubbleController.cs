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
		client.GetWords (word, p);
	}

	public void DefineWord (string[] words, Vector3 p)
	{


		bubbleGenerator.GenerateBubbles (words, p);
	}

}
