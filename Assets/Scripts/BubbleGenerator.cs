using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

  // 追加

public class BubbleGenerator : MonoBehaviour
{

	const float radius = 1.8f;
	// 泡が広がる時の円の半径
	const float time = 1.5f;
	// 泡が広がる時間

	[SerializeField] GameObject prefab;
	// 泡のprefab

	public void GenerateBubbles (string[] s, Vector3 pos)
	{
		float radian = (360f / (float)s.Length) * Mathf.PI / 180f;
		for (int i = 0; i < s.Length; i++) {
			GameObject obj = (GameObject)Instantiate (
				                 prefab,
				                 pos,
				                 Quaternion.identity
			                 );
			obj.transform.parent = gameObject.transform;

			// 泡にテキストをセットする
			Bubble bubble = obj.GetComponent<Bubble> ();
			bubble.Set (s [i]);

			// 泡が広がる動き
			obj.transform.DOMove (
				new Vector3 (pos.x + Mathf.Cos (radian * i) * radius, pos.y + Mathf.Sin (radian * i) * radius, 0),
				time
			).SetEase (Ease.OutCirc);
//			bubble.AddForce (new Vector3 (pos.x + Mathf.Cos (radian * i) * radius, pos.y + Mathf.Sin (radian * i) * radius, 0));
		}
	}
}
