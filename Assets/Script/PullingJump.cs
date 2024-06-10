using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{

    private bool isCanJump;

    private Rigidbody rb;
    private Vector3 clickPos;
    [SerializeField]
    private float jumpPower = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb  = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            clickPos = Input.mousePosition;
        }

        if (isCanJump && Input.GetMouseButtonUp(0)) {
            // クリックした座標と離した座標の差分を取得
            Vector3 dist = clickPos - Input.mousePosition;
            // クリックとリソースが同じならば無視
            if(dist.sqrMagnitude == 0) { return; }
            // 差分を標準化し,jumpPowerをかけ合わせた値を移動量とする
            rb.velocity = dist.normalized * jumpPower;
        }
    }
	private void OnCollisionEnter(Collision collision) {
        Debug.Log("衝突した");
	}

	private void OnCollisionStay(Collision collision) {
        // 衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        // 0番目の衝突情報から、衝突している点の法線を取得
        Vector3 otherNormal = contacts[0].normal;
        // 上方向ベクトル
        Vector3 upVector = new Vector3(0, 1, 0);
        // 上方向と法線の内積
        float dotUN = Vector3.Dot(upVector, otherNormal);
        // 内積値に逆三角関数arccosをかけて角度を算出
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        // 2つのベクトルのなす角が45度より小さければ再びジャンプ
        if(dotDeg <= 45) {
            isCanJump = true;
        }
	}
	private void OnCollisionExit(Collision collision) {
		isCanJump = false;
	}
}
