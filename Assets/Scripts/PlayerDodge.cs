using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerScore)), RequireComponent(typeof(CharacterController))]
public class PlayerDodge : MonoBehaviour {
    [SerializeField] private LayerMask layer;
    [SerializeField] private float baseLength = 0.325f, doubleLength = 0.175f;

    private float BaseLength => CharacterController.radius + baseLength;
    private float DoubleLength => CharacterController.radius + doubleLength;

    private readonly Dictionary<GameObject, float> dodgedObstaclesFront = new Dictionary<GameObject, float>();
    private readonly Dictionary<GameObject, float> dodgedObstaclesBack = new Dictionary<GameObject, float>();
    private readonly Dictionary<GameObject, float> dodgedObstaclesSide = new Dictionary<GameObject, float>();


    private PlayerScore playerScore;

    private CharacterController CharacterController => characterController
        ? characterController
        : characterController = GetComponent<CharacterController>();

    private CharacterController characterController;

    private void Awake() {
        playerScore = GetComponent<PlayerScore>();
    }

    private void Update() {
        CheckCollisions(new Ray(transform.position, transform.forward), dodgedObstaclesFront, "Front");
        CheckCollisions(new Ray(transform.position, -transform.forward), dodgedObstaclesBack, "Back");
        CheckCollisions(new Ray(transform.position, transform.right), dodgedObstaclesSide, "Right");
        CheckCollisions(new Ray(transform.position, -transform.right), dodgedObstaclesSide, "Left");
    }

    private void CheckCollisions(Ray ray, IDictionary<GameObject, float> dictionary, string text, float multiplier = 1) {
        var doubleHit = Physics.Raycast(ray, out var hit, DoubleLength, layer);
        var baseHit = Physics.Raycast(ray, out hit, BaseLength, layer);
        if (!doubleHit && !baseHit)
            return;

        var value = doubleHit ? 2 * multiplier : multiplier;
        if (dictionary.TryGetValue(hit.collider.gameObject, out var oldValue)) {
            if (oldValue > value)
                return;
            dictionary[hit.collider.gameObject] = value;
            playerScore.Multiplier += value - oldValue;
            Debug.Log(doubleHit ? text.ToUpper() : text);
            return;
        }

        dictionary.Add(hit.collider.gameObject, value);
        playerScore.Multiplier += value;
        Debug.Log(doubleHit ? text.ToUpper() : text);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, BaseLength * transform.forward);
        Gizmos.DrawRay(transform.position, -BaseLength * transform.forward);
        Gizmos.DrawRay(transform.position, BaseLength * transform.right);
        Gizmos.DrawRay(transform.position, -BaseLength * transform.right);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, DoubleLength * transform.forward);
        Gizmos.DrawRay(transform.position, -DoubleLength * transform.forward);
        Gizmos.DrawRay(transform.position, DoubleLength * transform.right);
        Gizmos.DrawRay(transform.position, -DoubleLength * transform.right);
    }
}