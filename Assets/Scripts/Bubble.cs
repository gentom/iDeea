using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{

	const float waitTime = 0.2f;

	[SerializeField] Rigidbody2D body;
	public TextMesh textMesh;
	BubbleController bubbleController;
	Vector3 screenPoint;
	Vector3 offset;
	Vector3 startPos;

	float time = 0;
	bool onTouch;

	// Use this for initialization
	void Start ()
	{
		bubbleController = transform.parent.gameObject.GetComponent<BubbleController> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (onTouch) {
			time += Time.deltaTime;
		}
	}

	public void Set (string text)
	{
		textMesh.text = text;
	}

	public void AddForce (Vector3 vector)
	{
		body.AddForce (vector * 0.5f);
	}

	void GenerateRelatedBubbles ()
	{
		bubbleController.DefineWord (textMesh.text, transform.position);
		Destroy (gameObject);
	}

	void Fusion (GameObject other)
	{
		textMesh.text += other.GetComponent<Bubble> ().textMesh.text;
		Destroy (other);
	}

	// タッチされた時
	void OnMouseDown ()
	{
		onTouch = true;

		// マウスカーソルは、スクリーン座標なので、
		// 対象のオブジェクトもスクリーン座標に変換してから計算する。

		// このオブジェクトの位置(transform.position)をスクリーン座標に変換。
		screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		// ワールド座標上の、マウスカーソルと、対象の位置の差分。
		offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		startPos = transform.position;
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
		onTouch = false;
		if (time < waitTime) {
			GenerateRelatedBubbles ();
		} else {
			AddForce (new Vector3 (transform.position.x - startPos.x, transform.position.y - startPos.y, 0f));
		}
		time = 0;
	}

	void OnTriggerStay2D (Collider2D other)
	{
		float x = transform.position.x - other.transform.position.x;
		float y = transform.position.y - other.transform.position.y;
		if (x * x + y * y < 0.05f && onTouch) {
			Fusion (other.gameObject);
		} else {
			AddForce (new Vector3 (x + 0.5f, y + 0.2f, 0f));
		}
	}
}
