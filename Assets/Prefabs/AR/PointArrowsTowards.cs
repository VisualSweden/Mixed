using UnityEngine;
using System.Collections;

public class PointArrowsTowards : MonoBehaviour {

    public GameObject arrowPrefab;

    private GameObject arrow;

    public void OnEnable() {
        if (!arrow) {
            arrow = Instantiate(arrowPrefab);
            arrow.GetComponent<ArrowPointing>().pointTowards = gameObject;
        }
    }

    public void OnDisable() {
        if (arrow) {
            Destroy(arrow);
            arrow = null;
        }
    }
}
