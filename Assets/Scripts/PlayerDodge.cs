using UnityEngine;

public class PlayerDodge : MonoBehaviour {
    [SerializeField] private LayerMask layer;
    [SerializeField] private float sideLength = 0.7f;

    private void Update() {
        if (
            Physics.Raycast(transform.position, -transform.right, sideLength, layer)
            || Physics.Raycast(transform.position, transform.right, sideLength, layer)
        ) {
            Debug.Log("Dodge!");
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawRay(transform.position, -sideLength * transform.right);
        Gizmos.DrawRay(transform.position, sideLength * transform.right);
    }
}
