using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoalItemScript : MonoBehaviour {

    public Camera camera_;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("goal");
        GameObject player = GameObject.FindWithTag("Player");
        camera_.GetComponent<CameraMove>().ZoomUpInit(player.transform.position, 50.0f);
    }
}
