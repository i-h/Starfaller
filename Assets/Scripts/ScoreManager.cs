using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public float ScorePerSecond = 100;
    public static float Score = 0;
    private void FixedUpdate()
    {
        if (PlayerManager.IsAlive)
        {
            Score += ScorePerSecond * Time.fixedDeltaTime;
        }
        
    }

#if UNITY_EDITOR
    private void OnGUI()
    {
        GUILayout.Label("Score: " + Score);
    }
#endif
}
