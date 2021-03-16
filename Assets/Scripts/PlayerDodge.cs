using UnityEngine;

public class PlayerDodge : MonoBehaviour {
    private void OnDrawGizmos() {
        Gizmos.DrawRay(transform.position - 0.5f * transform.right, -transform.right);
        Gizmos.DrawRay(transform.position + 0.5f * transform.right, transform.right);
    }
}
