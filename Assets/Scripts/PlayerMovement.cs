using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField, Min(0)] private float speed;
    public float Speed => speed;

    private CharacterController controller;
    private new Camera camera;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        camera = FindObjectOfType<Camera>();
    }

    private void FixedUpdate() {
        var leftmostPoint = camera.WorldToScreenPoint(new Vector3(-2, transform.position.y, transform.position.z)).x;
        var rightmostPoint = camera.WorldToScreenPoint(new Vector3(2, transform.position.y, transform.position.z)).x;

        var mousePos = Mathf.InverseLerp(leftmostPoint, rightmostPoint, Input.mousePosition.x);
        controller.Move(new Vector3(-2 + mousePos * 4 - transform.position.x, 0, Time.fixedDeltaTime * speed));
    }
}
