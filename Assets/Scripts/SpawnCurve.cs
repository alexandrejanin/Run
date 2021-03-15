using UnityEngine;

public class SpawnCurve : MonoBehaviour {
    [SerializeField] private AnimationCurve yPosition;
    [SerializeField] private float yOffset;
    private PlayerMovement player;

    private void Awake() {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update() {
        var dist = transform.position.z - player.transform.position.z;
        if (dist < -15)
            Destroy(gameObject);
        else
            transform.position = new Vector3(transform.position.x, yOffset + yPosition.Evaluate(dist / player.Speed), transform.position.z);
    }
}
