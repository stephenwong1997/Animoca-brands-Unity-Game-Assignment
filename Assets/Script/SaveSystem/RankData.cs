using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class RankData
{
    public static List<int> scores = new List<int>();

    public static void SetNewRecord(int score)
    {
        if (scores.Count == 0)
        {
            scores.Add(score);
            return;
        }
        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] <= score)
            {
                scores.Insert(i, score);
                return;
            }
        }
        scores.Add(score);
        return;

    }

    public static  int CheckRank(int score)
    {
        if (scores.Count <= 0)
        {
            return 0;
        }
        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] <= score)
            {
                return i;
            }
        }
        if (scores.Count<5) {
            return scores.Count;
        }
        return -1;
    }

}
