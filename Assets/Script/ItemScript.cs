using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ê⁄êGÇµÇΩèuä‘
    /// </summary>
    /// <param name="other"></param>
	private void OnTriggerEnter(Collider other) {
        //DestroySelf();
		animator.SetTrigger("Get");
        audioSource.Play();
	}

    /// <summary>
    /// ê⁄êGíÜ
    /// </summary>
    /// <param name="other"></param>
	private void OnTriggerStay(Collider other) {

	}

    /// <summary>
    /// ó£íEéû
    /// </summary>
    /// <param name="other"></param>
	private void OnTriggerExit(Collider other) {
		
	}

	private void DestroySelf() {
        Destroy(gameObject);
	}
}
