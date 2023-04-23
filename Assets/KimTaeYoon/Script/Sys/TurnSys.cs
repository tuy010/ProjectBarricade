using InfimaGames.LowPolyShooterPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnSys : MonoBehaviour
{
    [Title("Spawner")]
    [SerializeField]
    private ZombieSpawner[] zombieSpawners;

    [Title("Game")]
    [SerializeField]
    private bool isEnd;

    [Title("Player")]
    [SerializeField]
    private GameObject player;

    [Title("Timer")]
    [SerializeField]
    private float playTime;
    [SerializeField]
    private float stageTime;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float timer;
    [SerializeField]
    private int spawnCount;
    [SerializeField]
    private int spawnerCount;

    private int stageCount;

    public bool GetIsEnd() => isEnd;

    private void Start()
    {
        playTime = 0;
        stageTime = 0;
        spawnTime = 10;
        stageCount = 0;
        spawnCount = 3;
        spawnerCount = 3;
        timer = spawnTime;
        isEnd = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(!isEnd)
        {
            playTime += Time.deltaTime;
            stageTime += Time.deltaTime;
            timer += Time.deltaTime;

            if (stageTime > 30)
            {
                stageCount++;
                if (stageCount % 3 == 1)
                {
                    spawnTime = spawnTime / 10 * 9;
                }
                else if (stageCount % 3 == 2)
                {
                    spawnCount++;
                }
                else if (spawnCount % 3 == 0)
                {
                    spawnerCount++;
                }
                stageTime = 0;
            }

            if (timer >= spawnTime)
            {
                timer = 0;
                List<int> nums = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
                int randSpawner = Random.Range(1, spawnerCount);
                for (int i = 0; i < randSpawner; i++)
                {
                    int randIdx = Random.Range(0, nums.Count);
                    int randCount = Random.Range(1, spawnCount + 1);
                    zombieSpawners[nums[randIdx]].SpawnEnemy(randCount);
                    nums.Remove(randIdx);
                }
            }
        }
    }

    public void EndGame(Vector3 pos)
    {
        isEnd = true;
        player.GetComponent<PlayerInput>().enabled = false;
        player.GetComponent<Character>().enabled = false;
        player.transform.LookAt(pos);
    }
}
