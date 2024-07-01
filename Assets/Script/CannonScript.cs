using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class CanonScript : MonoBehaviour {

	// �v���C���[��Rigidbody
	private Rigidbody playerRb;

	// �ˏo���x�̑傳
	private float launchSpeed = 15.0f;
	private bool isPlayerStandBy = false;
	private Transform cannonTransform;
	private Collider cannonCollider;
	// UI�̎Q��
	public GameObject launchUI;

	// Start is called before the first frame update
	void Start() {
		playerRb = GetComponent<Rigidbody>();
		// UI�̔�\��
		launchUI.SetActive(false);

	}

	// Update is called once per frame
	void Update() {
		if (isPlayerStandBy) {
			transform.position = cannonTransform.position;

			if (Input.GetKey(KeyCode.Space)) {
				// ��C��x���������擾
				Vector3 launchDirection = -cannonTransform.right;

				// �������炷
				transform.position += launchDirection * 2.0f;
				// player��velocity���C��x�������ɐݒ�
				playerRb.velocity = launchDirection * launchSpeed;

				Debug.Log(playerRb.velocity);

				// player�̏d�͂�L���ɂ���
				playerRb.useGravity = true;

				// ���ˏ�Ԃ����Z�b�g
				isPlayerStandBy = false;

				// �����蔻��𕜋A
				cannonCollider.enabled = true;

				// UI�̔�\��
				launchUI.SetActive(false);

			}
		}
	}

	public void OnCollisionEnter(Collision collision) {
		// �Փ˂����I�u�W�F�N�g��cannon�^�O�������Ă��邩
		if (collision.collider.CompareTag("Cannon")) {
			// �Փ˂�����C�I�u�W�F�N�g��collider�𖳌��ɂ���
			cannonCollider = collision.collider;
			cannonCollider.enabled = false;

			// �v���C���[�̈ʒu���C�̈ʒu�Ɉړ�
			cannonTransform = cannonCollider.transform;
			transform.position = cannonTransform.position;

			// player�̏d�͂������ɂ���
			playerRb.useGravity = false;

			// player��ҋ@��Ԃɂ�����
			isPlayerStandBy = true;

			// UI�̕\��
			launchUI.SetActive(true);
			Vector3 transformUI = new Vector3(transform.position.x + 1.0f, transform.position.y + 1.0f, transform.position.z);
			//launchUI.transform.position = transformUI;
		}
	}
}
