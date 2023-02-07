using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_enemy : MonoBehaviour
{
    public GameObject Enemy_1;
    public float Enemy_1_countDown = 0;
    public float Enemy_1_DelayCoutDown = 1;
    public int Enemy_1_LimitSpwan = 100;
    public Transform[] SpawnPoint_Enemy_1;

    /// <summary>
    /// //////////////////////////////
    /// </summary>

    public GameObject Enemy_2;
    public float Enemy_2_countDown = 0;
    public float Enemy_2_DelayCoutDown = 1;
    public int Enemy_2_LimitSpwan = 100;
    public Transform[] SpawnPoint_Enemy_2;


    public int EnemyInRoom = 0;

    void Start()
    {
        Enemy_1_countDown = Enemy_1_DelayCoutDown;
        Enemy_2_countDown = Enemy_2_DelayCoutDown;     
    }

    public void Update()
    {
        Enemy_1_countDown -= Time.deltaTime;
        Enemy_2_countDown -= Time.deltaTime;

        if (Enemy_1_countDown < 0 && EnemyInRoom < Enemy_1_LimitSpwan)
            SpawnEnemy_1();

        if (Enemy_2_countDown < 0 && EnemyInRoom < Enemy_2_LimitSpwan)
            SpawnEnemy_2();
    }

    void SpawnEnemy_1()
    {
        Enemy_1_countDown = Enemy_1_DelayCoutDown;

        int randomNumber_1 = Random.Range(0, SpawnPoint_Enemy_1.Length);
        Instantiate(Enemy_1, SpawnPoint_Enemy_1[randomNumber_1].transform.position, Quaternion.identity);

        EnemyInRoom++;

    }

    void SpawnEnemy_2()
    {
        Enemy_2_countDown = Enemy_2_DelayCoutDown;

        int randomNumber_2 = Random.Range(0, SpawnPoint_Enemy_2.Length);
        Instantiate(Enemy_2, SpawnPoint_Enemy_2[randomNumber_2].transform.position, Quaternion.identity);

        EnemyInRoom++;

    }

}
