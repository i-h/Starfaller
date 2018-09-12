using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    public static float HazardSpeed = 2.0f;
    public float RandomRotation;
    private void Awake()
    {
        RandomRotation = Random.Range(-0.3f, 0.3f);
    }
    private void Update()
    {
        if (PlayerManager.IsPaused) return;
        transform.Translate(Vector3.up * HazardSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, RandomRotation);
        if (transform.position.y > 10) Destroy(gameObject);
    }
}
