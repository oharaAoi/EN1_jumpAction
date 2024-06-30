using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelScript : MonoBehaviour {

	private Rigidbody playerRb;

	// Start is called before the first frame update
	void Start() {
		playerRb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {

	}

	public void OnCollisionEnter(Collision collision) {
		// �Փ˂����I�u�W�F�N�g�������p�̃I�u�W�F�N�g��������
		if (collision.collider.CompareTag("Accelerator")) {
			// �Փ˂����I�u�W�F�N�g��rigidbody���擾
			Rigidbody collisionRb = collision.collider.GetComponent<Rigidbody>();


			// �Փ˂����I�u�W�F�N�g�̏�����̃x�N�g�����擾
			Vector3 upDirection = collision.collider.transform.up;

			//�@�v���C���[��velocity���Փ˂����I�u�W�F�N�g�̏�����̃x�N�g���ɐݒ�
			playerRb.velocity = upDirection * playerRb.velocity.magnitude * 3.0f;
		}
	}
}
