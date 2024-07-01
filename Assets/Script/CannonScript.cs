using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class CanonScript : MonoBehaviour {

	// プレイヤーのRigidbody
	private Rigidbody playerRb;

	// 射出速度の大さ
	private float launchSpeed = 15.0f;
	private bool isPlayerStandBy = false;
	private Transform cannonTransform;
	private Collider cannonCollider;
	// UIの参照
	public GameObject launchUI;

	// Start is called before the first frame update
	void Start() {
		playerRb = GetComponent<Rigidbody>();
		// UIの非表示
		launchUI.SetActive(false);

	}

	// Update is called once per frame
	void Update() {
		if (isPlayerStandBy) {
			transform.position = cannonTransform.position;

			if (Input.GetKey(KeyCode.Space)) {
				// 大砲のx軸方向を取得
				Vector3 launchDirection = -cannonTransform.right;

				// 少しずらす
				transform.position += launchDirection * 2.0f;
				// playerのvelocityを大砲のx軸方向に設定
				playerRb.velocity = launchDirection * launchSpeed;

				Debug.Log(playerRb.velocity);

				// playerの重力を有効にする
				playerRb.useGravity = true;

				// 発射状態をリセット
				isPlayerStandBy = false;

				// 当たり判定を復帰
				cannonCollider.enabled = true;

				// UIの非表示
				launchUI.SetActive(false);

			}
		}
	}

	public void OnCollisionEnter(Collision collision) {
		// 衝突したオブジェクトがcannonタグを持っているか
		if (collision.collider.CompareTag("Cannon")) {
			// 衝突した大砲オブジェクトのcolliderを無効にする
			cannonCollider = collision.collider;
			cannonCollider.enabled = false;

			// プレイヤーの位置を大砲の位置に移動
			cannonTransform = cannonCollider.transform;
			transform.position = cannonTransform.position;

			// playerの重力も無効にする
			playerRb.useGravity = false;

			// playerを待機状態にさせる
			isPlayerStandBy = true;

			// UIの表示
			launchUI.SetActive(true);
			Vector3 transformUI = new Vector3(transform.position.x + 1.0f, transform.position.y + 1.0f, transform.position.z);
			//launchUI.transform.position = transformUI;
		}
	}
}
