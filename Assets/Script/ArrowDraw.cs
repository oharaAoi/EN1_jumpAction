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

        // �I�u�W�F�N�g�𖳌����ɂ��Ă���
		arrowImage.gameObject.SetActive(false);

		if (Input.GetMouseButton(0)) {
            // �I�u�W�F�N�g�̗L����
            arrowImage.gameObject.SetActive(true);
            Vector3 dist = clickPos - Input.mousePosition;
            // �������v�Z
            float size = dist.magnitude;
            // �x�N�g������p�x���v�Z
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            // ���̉摜���N���b�N�����ꏊ�Ɉړ�
            arrowImage.rectTransform.position = clickPos;
            // �摜�̊p�x���v�Z�����p�x��x���@�ɂ���z����]
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            //�摜�̑傳���h���b�N�̋����ɍ��킹��
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
            //Debug.Log(dist);
        } 
    }
}
