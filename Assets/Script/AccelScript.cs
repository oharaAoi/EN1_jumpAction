using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelScript : MonoBehaviour {

	private Rigidbody playerRb;

	// Start is called before the first frame update
	void Start() {
		playerRb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {

	}

	public void OnCollisionEnter(Collision collision) {
		// 衝突したオブジェクトが加速用のオブジェクトだったら
		if (collision.collider.CompareTag("Accelerator")) {
			// 衝突したオブジェクトのrigidbodyを取得
			Rigidbody collisionRb = collision.collider.GetComponent<Rigidbody>();


			// 衝突したオブジェクトの上方向のベクトルを取得
			Vector3 upDirection = collision.collider.transform.up;

			//　プレイヤーのvelocityを衝突したオブジェクトの上方向のベクトルに設定
			playerRb.velocity = upDirection * playerRb.velocity.magnitude * 3.0f;
		}
	}
}
