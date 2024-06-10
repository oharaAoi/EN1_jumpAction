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
    public float zoomSpeed = 2.0f;// �Y�[�����x
    public float moveSpeed = 2.0f;// �J�����̈ړ����x


    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isZooming) {
            // �J�����̃Y�[�����ړ�
            //camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
            // �J�����̈ʒu���ړ�
            camera.transform.position = Vector3.Lerp(camera.transform.position, targetPos, Time.deltaTime * moveSpeed);
            // �Y�[���ƈړ����ڕW�l�ɒB������
            if (Vector3.Distance(transform.position, targetPos) < 10.0f) {
				//camera.orthographicSize = targetZoom;
				transform.position = targetPos;
				isZooming = false;
			}
        }
    }

    /// <summary>
    /// �Y�[���̏���������������
    /// </summary>
    /// <param name="playerPos"></param>
    /// <param name="newZoom"></param>
    public void ZoomUpInit(Vector3 playerPos, float newZoom) {
        targetPos = new Vector3(playerPos.x, playerPos.y, playerPos.z - 4.0f);
        targetZoom = newZoom;
        isZooming = true;
    }
}
