using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSpriteBackground : MonoBehaviour {
    public float Speed = 1.0f;
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up * Speed * Time.deltaTime;
	}
}
