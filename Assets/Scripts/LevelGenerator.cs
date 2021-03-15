using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField, Min(0)] private float minLength = 30;
    [SerializeField] private Transform player;

    [SerializeField] private List<LevelPiece> piecePrefabs;
    [SerializeField] private List<LevelPiece> pieces;

    [SerializeField] private List<GameObject> wallPrefabs;
    [SerializeField] private List<GameObject> walls;

    private void Update() {
        pieces.RemoveAll(p => !p);
        while (pieces.Last().EndPoint.position.z < player.transform.position.z + minLength)
            SpawnPiece();

        walls.RemoveAll(w => !w);
        while (walls.Last().transform.position.z < player.transform.position.z + minLength)
            SpawnWall();
    }

    private void SpawnWall() {
        var prefab = wallPrefabs[Random.Range(0, wallPrefabs.Count)];
        var spawnPos = walls.Last().transform.position + Vector3.forward * (walls.Last().transform.lossyScale.z + 0.5f);
        spawnPos.x = Random.Range(-3.5f, -2.5f);
        var piece = Instantiate(
            prefab,
            spawnPos,
            prefab.transform.rotation
        );
        walls.Add(piece);
    }

    private void SpawnPiece() {
        var prefab = piecePrefabs[Random.Range(0, piecePrefabs.Count)];
        var piece = Instantiate(prefab, pieces.Last().EndPoint.position, prefab.transform.rotation);
        pieces.Add(piece);
    }
}
