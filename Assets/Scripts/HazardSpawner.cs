using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour {
    public float SpawnInterval = 2.0f;
    public List<Transform> HazardPrefabs = new List<Transform>();
    float _lastSpawnTime = 0;
	
	// Update is called once per frame
	void Update () {
		if(Time.time - _lastSpawnTime > SpawnInterval)
        {
            if(!PlayerManager.IsPaused) SpawnHazard();
            _lastSpawnTime = Time.time;
        }
	}

    private void SpawnHazard()
    {
        int random = Random.Range(0, HazardPrefabs.Count);
        Transform h = Instantiate<Transform>(HazardPrefabs[random]);
        Vector3 newPos = transform.position;
        newPos.x = Random.Range(-3, 3);
        h.position = newPos;
    }
}
