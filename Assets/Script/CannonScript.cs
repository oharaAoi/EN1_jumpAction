using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{

    // �v���C���[��Rigidbody
    private Rigidbody playerRb;

    // �ˏo���x�̑傳
    public float launchSpeed = 5.0f;

	// Start is called before the first frame update
	void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnCollisionEnter(Collision collision) {
        // �Փ˂����I�u�W�F�N�g��cannon�^�O�������Ă��邩
        if (collision.collider.CompareTag("Cannon")) {
            // �Փ˂�����C��x���������擾
            Vector3 launchDirection = collision.transform.right;

            // player��velocity���C��x�������ɐݒ�
            playerRb.velocity = launchDirection * launchSpeed;
        }
	}
}
