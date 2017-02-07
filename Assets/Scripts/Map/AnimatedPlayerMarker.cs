using UnityEngine;
using System.Collections;

public class AnimatedPlayerMarker : MonoBehaviour {

    private Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
        MapManager.Instance.location.OnLocationChanged += (Vector2 v) => {
            animator.SetTrigger("GotPosition");
        };
	}
}
