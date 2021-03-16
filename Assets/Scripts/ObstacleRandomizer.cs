using System.Linq;
using UnityEngine;

public class ObstacleRandomizer : MonoBehaviour {
    [SerializeField] private GameObject[] obstacles;

    private void Awake() {
        do {
            foreach (var o in obstacles)
                o.SetActive(Random.Range(0f, 1f) < 0.5f);
        } while (obstacles.All(o => o.activeSelf) || obstacles.All(o => !o.activeSelf));
    }
}
