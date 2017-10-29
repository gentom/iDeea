using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {

	[SerializeField] Client client;
	BubbleGenerator bubbleGenerator;

	// Use this for initialization
	void Start ()
	{
		bubbleGenerator = GetComponent<BubbleGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void DefineWord (string word)
	{
		// ここでClientにwordを渡す


		bubbleGenerator.GenerateBubbles (client.GetWords (), Vector3.zero);
	}

	public void DefineWord (string word, Vector3 pos)
	{
		// ここでClientにwordを渡す


		bubbleGenerator.GenerateBubbles (client.GetWords (), pos);
	}

}
