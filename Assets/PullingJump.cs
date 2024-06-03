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
        if (isCanJump && Input.GetMouseButtonDown(0)) {
            clickPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) {
            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPos - Input.mousePosition;
            // �N���b�N�ƃ��\�[�X�������Ȃ�Ζ���
            if(dist.sqrMagnitude == 0) { return; }
            // ������W������,jumpPower���������킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;
        }
    }

	private void OnCollisionEnter(Collision collision) {
        Debug.Log("�Փ˂���");
	}

	private void OnCollisionStay(Collision collision) {
        isCanJump = true;
	}

	private void OnCollisionExit(Collision collision) {
        isCanJump = false;
	}
}
