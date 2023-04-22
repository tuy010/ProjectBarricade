using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    #region FIELD SERIALIZED
    [Title("Resource")]
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform target;

    [Title("States")]
    [SerializeField] private float spawnRadius;
    [SerializeField] private float coolTime;
    [SerializeField] private int monsterCount;
    [SerializeField] private bool isOn;
    #endregion

    #region FIELD
    private Vector3 targetPoint;
    private float timer;
    #endregion

    #region UNITY
    private void Awake()
    {
        if (target == null)
            targetPoint = new Vector3(0, 0, 0);
    }

    //private void Update()
    //{
    //    if(timer < coolTime)
    //        timer += Time.deltaTime;
    //    else
    //    {
    //        for (int i = 0; i < monsterCount; i++)
    //        {                
    //            Invoke("SpawnEnemy", Random.Range(0, 1f));
    //        }
    //        timer = 0;
    //    }
    //}
    #endregion

    #region METHODS
    public void SpawnEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Invoke("SpawnFunc", Random.Range(0, 1f));
        }
        timer = 0;
    }
    private void SpawnFunc()
    {
        float randomx = Random.Range(-spawnRadius, +spawnRadius);
        float randomz = Random.Range(-spawnRadius, +spawnRadius);
        GameObject projectile = Instantiate(enemy, this.transform.position + new Vector3(randomx, 0, randomz), Quaternion.identity);
    }
    #endregion
}
