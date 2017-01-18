using UnityEngine;
using System.Collections;

public class BubbleManager : MonoBehaviour {

    public int NumberOfBubbles;
    public float SpawnRadius;

    public GameObject BubblePrefab;

    public float MinLifetime;
    public float MaxLifetime;

    public Vector3 BaseSpeed;
    public Vector3 Amplitude;
    public float MaxFrequency;
    public float SpawnDelay;

    private Bubble[] Bubbles;

    void Awake () {
        Bubbles = new Bubble[NumberOfBubbles];
        for(int i = 0; i<NumberOfBubbles; i++) {
            GameObject Object = Instantiate<GameObject>(BubblePrefab);
            Object.transform.SetParent(transform);
            Bubbles[i] = Object.GetComponent<Bubble>();
           // Bubbles[i].OnBubbleDestroyed += delegate(Bubble b) { SetupBubble(b); };
        }
	}

    void OnEnable() {
        StopCoroutine(AnimateBubbles());
        StartCoroutine(AnimateBubbles());
    }

    private IEnumerator AnimateBubbles() {
        for (int i = 0; i < NumberOfBubbles; i++) {
            Bubbles[i].gameObject.SetActive(false);
        }

        for(int i = 0; i<NumberOfBubbles; i++) {
            SetupBubble(Bubbles[i]);
            yield return new WaitForSeconds(SpawnDelay);
        }
    }

    private void SetupBubble(Bubble bubble) {
        bubble.transform.position = transform.position + Random.insideUnitSphere * SpawnRadius;
        bubble.Lifetime = Random.Range(MinLifetime, MaxLifetime);
        bubble.BaseVelocity = BaseSpeed;
        bubble.Amplitude = Random.value * Amplitude;
        bubble.Frequency = MaxFrequency * Random.value;
        bubble.gameObject.SetActive(true);
    }
}
