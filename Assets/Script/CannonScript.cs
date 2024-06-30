using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{

    // プレイヤーのRigidbody
    private Rigidbody playerRb;

    // 射出速度の大さ
    public float launchSpeed = 5.0f;

	// Start is called before the first frame update
	void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnCollisionEnter(Collision collision) {
        // 衝突したオブジェクトがcannonタグを持っているか
        if (collision.collider.CompareTag("Cannon")) {
            // 衝突した大砲のx軸方向を取得
            Vector3 launchDirection = collision.transform.right;

            // playerのvelocityを大砲のx軸方向に設定
            playerRb.velocity = launchDirection * launchSpeed;
        }
	}
}
