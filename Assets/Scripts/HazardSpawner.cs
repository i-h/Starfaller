using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour {
    public float SpawnInterval = 2.0f;
    public List<Hazard> HazardPrefabs = new List<Hazard>();
    float _lastSpawnTime = 0;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - _lastSpawnTime > SpawnInterval)
        {
            SpawnHazard();
            _lastSpawnTime = Time.time;
        }
	}

    private void SpawnHazard()
    {
        int random = Random.Range(0, HazardPrefabs.Count);
        Hazard h = Instantiate<Hazard>(HazardPrefabs[random]);
        Vector3 newPos = transform.position;
        newPos.x = Random.Range(-3, 3);
        h.transform.position = newPos;
    }
}
