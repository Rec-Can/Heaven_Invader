using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject pathPrefab;
    [SerializeField] string tag;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int numberOfEnemies = 5;
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }
    public string GetTag()
    {
        return tag;
    }
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }
    public float GetTimeBetweenWaves()
    {
        return timeBetweenWaves;
    }
    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
}
