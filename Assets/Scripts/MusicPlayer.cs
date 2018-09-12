using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    public static MusicPlayer Instance;
    void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
	}
}
