using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveRankManager : MonoBehaviour
{
    private static string baseSavePath;

    // Start is called before the first frame update
    void Awake()
    {
        baseSavePath = Application.persistentDataPath;
        SaveRankManager[] objs = GameObject.FindObjectsOfType<SaveRankManager>();
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this);
        }
    
    }


    public static string[] GetRankData()
    {
        string[] data = new string[5];
        for (int i = 0; i < 5; i++)
        {
            if(RankData.scores.Count>i)
            data[i] = RankData.scores[i].ToString();
        }
        return data;
    }

    public static string GetFirstPlaceData()
    {
        List<int> data = new List<int>();
        if (RankData.scores.Count > 0)
        {
            data.Add(RankData.scores[0]);
            return "First place : " + data[0];
        }
        return "";
    }

    private void OnDestroy()
    {
        Save();
    }

    public static void LoadDataToRankData()
    {
        if (System.IO.File.Exists(baseSavePath + "/rank.dat"))
        {
            RankData.scores = FileReadWrite.ReadFromBinaryFile<List<int>>(baseSavePath + "/rank.dat");
        }
 
    }

    public static void Save()
    {
        if (RankData.scores.Count > 0)
            FileReadWrite.WriteToBinaryFile(baseSavePath + "/rank.dat", RankData.scores);
    }
}
