using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加

public class Bubble : MonoBehaviour {

	[SerializeField] public TextMesh textMesh;
	Vector3 screenPoint;
	Vector3 offset;
	
	public void Set (string text)
	{
		textMesh.text = text;
	}

	// タッチされた時
	void OnMouseDown ()
	{
		print ("down");
		// マウスカーソルは、スクリーン座標なので、
		// 対象のオブジェクトもスクリーン座標に変換してから計算する。

		// このオブジェクトの位置(transform.position)をスクリーン座標に変換。
		screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		// ワールド座標上の、マウスカーソルと、対象の位置の差分。
		offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	// ドラッグ中
	void OnMouseDrag ()
	{
		Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint) + this.offset;
		transform.position = currentPosition;
	}

	// タッチが離れた時
	void OnMouseUp ()
	{
		print ("up");
	}

	// frameと重なった時の処理
	void OnTriggerEnter2D (Collider2D bubble) {
		print ("重なった");
		print(bubble.gameObject.GetComponent<Bubble> ().textMesh.text);
	}
}
