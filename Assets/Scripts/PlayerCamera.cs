using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    [SerializeField] private PlayerMovement player;

    private Vector3 offset;

    private void Awake() {
        offset = transform.position - player.transform.position;
    }

    private void Update() {
        var targetPos = player.transform.position;
        targetPos.x = 0;
        transform.position = targetPos + offset;
    }
}
