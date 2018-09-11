using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTextureBackground : MonoBehaviour {
    public float Speed = 1.0f;
    Renderer _r;
    Vector2 _offset = new Vector2();

    private void Awake()
    {
        _r = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        _offset.y += Speed * Time.deltaTime;
        _offset.y %= 1;
        _r.material.mainTextureOffset = _offset;
	}
}
