using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> wayPoints;
    [SerializeField] int wayPointsIndex = 0;
    void Start()
    {
        wayPoints = waveConfig.GetWaypoints();
        transform.position = wayPoints[wayPointsIndex].transform.position;
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (wayPointsIndex <= wayPoints.Count - 1)
        {
            Vector3 targetPos = wayPoints[wayPointsIndex].transform.position;
            float moveThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveThisFrame);
            if (transform.position == targetPos)
            {
                wayPointsIndex++;
            }
        }
        else
        {
            wayPointsIndex = 0;
        }
    }
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
}
