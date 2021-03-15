using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {
    [SerializeField] private Text text;

    private void Update() {
        text.text = $"{transform.position.z:F0}";
    }
}
