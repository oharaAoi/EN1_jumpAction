using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private Camera camera;

    private Vector3 targetPos;
    private float targetZoom;
    private bool isZooming = false;
    public float zoomSpeed = 2.0f;// ズーム速度
    public float moveSpeed = 2.0f;// カメラの移動速度

    public GameObject clearText;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isZooming) {
            // カメラのズームを移動
            //camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
            // カメラの位置を移動
            camera.transform.position = Vector3.Lerp(camera.transform.position, targetPos, Time.deltaTime * moveSpeed);
            // ズームと移動が目標値に達したら
            float distance = Vector3.Distance(transform.position, targetPos);
            //Debug.Log("distance" + distance);
			if (Mathf.Floor(distance) <= 0.0f) {
				//camera.orthographicSize = targetZoom;
				transform.position = targetPos;
				isZooming = false;
                clearText.SetActive(true);
			}
        }
    }

    /// <summary>
    /// ズームの処理を初期化する
    /// </summary>
    /// <param name="playerPos"></param>
    /// <param name="newZoom"></param>
    public void ZoomUpInit(Vector3 playerPos, float newZoom) {
        targetPos = new Vector3(playerPos.x, playerPos.y, playerPos.z - 4.0f);
        targetZoom = newZoom;
        isZooming = true;
    }
}
