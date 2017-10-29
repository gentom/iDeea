using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  // 追加

public class BubbleCreator : MonoBehaviour {

	const float radius = 2.0f;  // 泡が広がる時の円の半径
	const float time = 1.5f;  // 泡が広がる時間

	[SerializeField] GameObject prefab;  // 泡のprefab
	[SerializeField] GameObject bubbleParent;  // 泡の親

	string[] s = {
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

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// InputFieldに入力されたテキストを受け取る
	public void InputText (string text)
	{
		Debug.Log (text);
		CreateBubbles (Vector3.zero);
	}

	void CreateBubbles (Vector3 pos)
	{
		float radian = (360f / (float)s.Length) * Mathf.PI / 180f;
		for (int i = 0; i < s.Length; i++) {
			GameObject obj = (GameObject)Instantiate (
				prefab,
				pos,
				Quaternion.identity
			);
			obj.transform.parent = bubbleParent.transform;

			// 泡にテキストをセットする
			Bubble bubble = obj.GetComponent<Bubble> ();
			bubble.Set (s[i]);

			// 泡が広がる動き
//			Sequence sequence = DOTween.Sequence();
			obj.transform.DOMove (
				new Vector3 (pos.x + Mathf.Cos(radian * i) * radius, pos.y + Mathf.Sin(radian * i) * radius, 0),
				time
			).SetEase(Ease.OutCirc);
		}
	}
}
