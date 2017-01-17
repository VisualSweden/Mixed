using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {
    public delegate void bubbleDelegate(Bubble bubble);

    private Animator animator;

    public Vector3 BaseVelocity;
    public Vector3 Amplitude;
    public float Frequency;
    public float Lifetime;

    public event bubbleDelegate OnBubbleDestroyed;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    void OnEnable () {
        Invoke("DestroyBubble", Lifetime);
	}

    public void DestroyBubble() {
        animator.SetTrigger("Explode");
    }

    public void ExplodeAnimationFinished() {
        gameObject.SetActive(false);
        OnBubbleDestroyed(this);
    }

    void OnMouseUpAsButton() {
        DestroyBubble();
    }
	
	void Update () {
        transform.localPosition += (BaseVelocity + Mathf.Sin(Frequency) * Amplitude) * Time.deltaTime;
	}
}
