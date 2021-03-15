using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    [SerializeField] private GameObject defeatMenu;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.CompareTag("Defeat")) {
            GetComponent<PlayerMovement>().enabled = false;
            defeatMenu.SetActive(true);
        }
    }
}
