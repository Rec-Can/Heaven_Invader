using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] ObjectPooler objectPooler;
    [SerializeField] int startingWave = 0;
    [HideInInspector] public float enemyCount;
    IEnumerator Start()
    {
        yield return StartCoroutine(SpawnAllWaves());                     
    }    
    IEnumerator SpawnAllWaves()
    {
        for (int i = startingWave; i < waveConfigs.Count; i++)
        {            
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            GameObject newEnemy = objectPooler.SpawnFromPool(
                waveConfig.GetTag(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            enemyCount++;

            if(newEnemy != null)
            {
                newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            }
            
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
        yield return new WaitForSeconds(waveConfig.GetTimeBetweenWaves());
    }    
}
