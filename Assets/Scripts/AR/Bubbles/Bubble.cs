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

    private Camera myCamera;

    private void Awake() {
        animator = GetComponent<Animator>();
        myCamera = FindObjectOfType<Vuforia.VuforiaBehaviour>().GetComponentInChildren<Camera>();
    }

    void OnEnable () {
        Invoke("DestroyBubble", Lifetime);
	}

    public void DestroyBubble() {
        animator.SetTrigger("Explode");
    }

    public void ExplodeAnimationFinished() {
        gameObject.SetActive(false);
        if (OnBubbleDestroyed != null)
            OnBubbleDestroyed(this);
    }

    void OnMouseUpAsButton() {
        DestroyBubble();
    }
	
	void Update () {
        transform.localPosition += (BaseVelocity + Mathf.Sin(Frequency) * Amplitude) * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(transform.position - myCamera.transform.position, transform.parent.up);
	}
}
