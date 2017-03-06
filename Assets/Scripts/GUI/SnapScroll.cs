using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnapScroll : MonoBehaviour {
    public ScrollRect rect;
    public GameObject content;

    public float period;
    public float snapSpeed;

    public int nextSlide;
	
	void Update () {
        bool isDragging = Input.touchCount > 0 || Input.GetMouseButton(0);

        if (!isDragging) {
            Vector3 p = content.transform.localPosition;
            float goal = nearestMultiplication(p.x);
            p.x = Mathf.Lerp(p.x, goal, Time.deltaTime * snapSpeed);
            content.transform.localPosition = p;
        }
    }

    public void moveToSlide(int slide) {
        Vector3 p = content.transform.localPosition;
        float goal = slide * period;
        p.x = -goal;
        content.transform.localPosition = p;
    }

    public float nearestMultiplication(float x) {
        return Mathf.RoundToInt(x / period) * period;
    }
}
