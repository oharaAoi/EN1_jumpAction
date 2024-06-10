using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
   

    [SerializeField]
    private Image arrowImage;
	private Vector3 clickPos;

	// Start is called before the first frame update
	void Start()
    {
		arrowImage.gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            clickPos = Input.mousePosition;
		}

        // オブジェクトを無効かにしておく
		arrowImage.gameObject.SetActive(false);

		if (Input.GetMouseButton(0)) {
            // オブジェクトの有効か
            arrowImage.gameObject.SetActive(true);
            Vector3 dist = clickPos - Input.mousePosition;
            // 長さを計算
            float size = dist.magnitude;
            // ベクトルから角度を計算
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            // 矢印の画像をクリックした場所に移動
            arrowImage.rectTransform.position = clickPos;
            // 画像の角度を計算した角度を度数法にしてz軸回転
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            //画像の大さをドラックの距離に合わせる
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
            //Debug.Log(dist);
        } 
    }
}
