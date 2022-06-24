using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject skeleton;
    public List<GameObject> skeletons;
    public Item soulStone;

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
        var newSkeleton = Instantiate(skeleton, new Vector3(0, 0, 0), Quaternion.identity);
        newSkeleton.GetComponent<EnemyAI>().target = player.transform;
        skeletons.Add(newSkeleton);
    }

    void SpawnSoulStone()
    {
        skeletons[0].GetComponent<Inventory>().Add(soulStone);
    }
}
