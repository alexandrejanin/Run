using UnityEngine;

public class ColorRandomizer : MonoBehaviour {
    [SerializeField] private Gradient gradient;

    private void Awake() {
        GetComponent<Renderer>().material.color = gradient.Evaluate(Random.Range(0f, 1f));
    }
}
