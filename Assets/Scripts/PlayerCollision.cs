using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject defeatMenu;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if ((layerMask & 1 << hit.gameObject.layer) != 0) {
            GetComponent<PlayerMovement>().enabled = false;
            defeatMenu.SetActive(true);
        }
    }
}
