using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    public static float HazardSpeed = 1.7f;
    private void Update()
    {
        transform.Translate(Vector3.up * HazardSpeed * Time.deltaTime);
        if (transform.position.y > 10) Destroy(gameObject);
    }
}
