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

    private Bubble[] Bubbles;

    IEnumerator Start () {
        Bubbles = new Bubble[NumberOfBubbles];
        for(int i = 0; i<NumberOfBubbles; i++) {
            GameObject Object = Instantiate<GameObject>(BubblePrefab);
            Object.transform.SetParent(transform);
            Bubbles[i] = Object.GetComponent<Bubble>();
            Bubbles[i].OnBubbleDestroyed += delegate(Bubble b) { SetupBubble(b); };
            SetupBubble(Bubbles[i]);
            yield return new WaitForSeconds(Random.Range(MinLifetime, MaxLifetime)/NumberOfBubbles);
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
