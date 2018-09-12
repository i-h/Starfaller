using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager Instance;
    public Text GemText;
    public float ScorePerSecond = 100;
    public static float Score = 0;
    public static Dictionary<GoodGem.GemType, int> GatheredGems = new Dictionary<GoodGem.GemType, int>();
    public static Dictionary<GoodGem.GemType, float> Scores = new Dictionary<GoodGem.GemType, float>();

    public Text[] Counts;
    public Text[] Totals;
    public Text GrandTotal;

    public void ShowEndScreen()
    {
        Counts[0].text = GatheredGems[GoodGem.GemType.GoodGem1].ToString();
        Counts[1].text = GatheredGems[GoodGem.GemType.GoodGem2].ToString();
        Counts[2].text = GatheredGems[GoodGem.GemType.GoodGem3].ToString();

        Totals[0].text = (GatheredGems[GoodGem.GemType.GoodGem1] * Scores[GoodGem.GemType.GoodGem1]) + "";
        Totals[1].text = (GatheredGems[GoodGem.GemType.GoodGem2] * Scores[GoodGem.GemType.GoodGem2]) + "";
        Totals[2].text = (GatheredGems[GoodGem.GemType.GoodGem3] * Scores[GoodGem.GemType.GoodGem3]) + "";

        GrandTotal.text = GetTotalScore() + "";
    }

    public void Awake()
    {
        GatheredGems.Clear();
        Instance = this;
        Scores.Add(GoodGem.GemType.GoodGem1, 100);
        Scores.Add(GoodGem.GemType.GoodGem2, 250);
        Scores.Add(GoodGem.GemType.GoodGem3, 500);
        GatheredGems.Add(GoodGem.GemType.GoodGem1, 0);
        GatheredGems.Add(GoodGem.GemType.GoodGem2, 0);
        GatheredGems.Add(GoodGem.GemType.GoodGem3, 0);
        UpdateGems();
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.IsPaused && PlayerManager.IsAlive)
        {
            Score += ScorePerSecond * Time.fixedDeltaTime;
        }
        
    }
    public static int GetTotalGems()
    {
        int counter = 0;
        foreach(int gemVal in GatheredGems.Values)
        {
            counter += gemVal;
        }
        return counter;
    }

    public static float GetTotalScore()
    {
        float sum = 0;
        foreach(KeyValuePair<GoodGem.GemType, int> g in GatheredGems)
        {
            sum += Scores[g.Key] * g.Value;
        }
        return sum;
    }

    public static void AddGem(GoodGem g)
    {
        if (GatheredGems.ContainsKey(g.Type))
        {
            GatheredGems[g.Type]++;
        } else
        {
            GatheredGems.Add(g.Type, 1);
        }

        Debug.Log("Gems: " + GatheredGems[g.Type]);
        Instance.UpdateGems();
    }

    public void UpdateGems()
    {
        GemText.text = GetTotalGems() + "";
    }
}
