using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{

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

        if (Input.GetMouseButtonUp(0)) {
            // クリックした座標と離した座標の差分を取得
            Vector3 dist = clickPos - Input.mousePosition;
            // クリックとリソースが同じならば無視
            if(dist.sqrMagnitude == 0) { return; }
            // 差分を標準化し,jumpPowerをかけ合わせた値を移動量とする
            rb.velocity = dist.normalized * jumpPower;
        }
    }
}
