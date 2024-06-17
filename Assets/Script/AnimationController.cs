using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator otherAnimator;
    public string nextAnimationName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnimationEnd() {
        otherAnimator.SetBool(nextAnimationName, true);
    }
}
