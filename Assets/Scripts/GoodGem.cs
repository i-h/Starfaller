using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGem : MonoBehaviour {
    public enum GemType { GoodGem1, GoodGem2, GoodGem3 }
    public GemType Type;
    public int Points = 100;
    public float GemSpeed = 1.9f;
    public float RandomRotation;

    private void Awake()
    {
        RandomRotation = Random.Range(-0.3f, 0.3f);
    }
    private void Update()
    {
        if (PlayerManager.IsPaused) return;
        transform.Translate(Vector3.up * GemSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, RandomRotation);
        if (transform.position.y > 10) Destroy(gameObject);
    }
}
