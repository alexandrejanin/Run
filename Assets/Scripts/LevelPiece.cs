using UnityEngine;

public class LevelPiece : MonoBehaviour {
    [SerializeField] private Transform endPoint;

    public Transform EndPoint => endPoint;
}
