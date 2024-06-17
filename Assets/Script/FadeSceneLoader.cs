using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSceneLoader : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration; // äÆóπÇ‹Ç≈ÇÃéûä‘

	private Animator animator;

	// Start is called before the first frame update
	void Start()
    {
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        StartAnimation();
	}

    public IEnumerator FadeOutAndLoadScene() {
        fadePanel.enabled = true;
        float elapsedTime = 0.0f;
        Color startColor = fadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        // é¿çs
        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadePanel.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        fadePanel.color = endColor;
    }
	public void StartAnimation() {
        if (Input.GetKey(KeyCode.D)) {
            animator.SetBool("startFadeOut", true);
        }
	}
}