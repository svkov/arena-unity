using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject skeleton;
    public GameObject priestess;
    public List<GameObject> skeletons;
    public Item soulStone;
    public GameObject itemObj;

    int spawn_skeleton_per_level;
    void Start()
    {
        spawn_skeleton_per_level = 5 * State.level_number;
        for(int i = skeletons.Count; skeletons.Count < spawn_skeleton_per_level; i++)
        {
            SpawnSkeleton();
        }
        SpawnSoulStone();
    }

    void SpawnSkeleton()
    {
        var newSkeleton = SpawnEnemyRandomly(skeleton);
        skeletons.Add(newSkeleton);
    }

    void SpawnSoulStone()
    {
        var newPriestess = SpawnEnemyRandomly(priestess);
        newPriestess.GetComponent<Inventory>().Add(soulStone);
    }


    GameObject SpawnEnemyRandomly(GameObject enemy)
    {
        var pos = GetRandomPosition();
        var newEnemy = Instantiate(enemy, pos, Quaternion.identity);
        newEnemy.GetComponent<EnemyAI>().target = player.transform;
        newEnemy.GetComponent<Inventory>().itemObj = itemObj;
        return newEnemy;
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.value * 200 - 100, Random.value * 200 - 100, 0);
    }
}
