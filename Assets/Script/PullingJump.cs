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
        // �Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        // 0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾
        Vector3 otherNormal = contacts[0].normal;
        // ������x�N�g��
        Vector3 upVector = new Vector3(0, 1, 0);
        // ������Ɩ@���̓���
        float dotUN = Vector3.Dot(upVector, otherNormal);
        // ���ϒl�ɋt�O�p�֐�arccos�������Ċp�x���Z�o
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        // 2�̃x�N�g���̂Ȃ��p��45�x��菬������΍ĂуW�����v
        if(dotDeg <= 45) {
            isCanJump = true;
        }
	}
	private void OnCollisionExit(Collision collision) {
		isCanJump = false;
	}
}
