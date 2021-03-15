using UnityEngine;

public class SizeRandomizer : MonoBehaviour {
    [SerializeField] private Vector3 min, max;

    private void Awake() {
        transform.localScale = new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z)
        );
    }
}
