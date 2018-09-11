using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGDebug : MonoBehaviour {
    public Text ValueText;
    public ScrollingTextureBackground Background;

    public void ValChanged(float s)
    {
        ValueText.text = "Background speed: " + s;
        Background.Speed = -s;
    }
}
