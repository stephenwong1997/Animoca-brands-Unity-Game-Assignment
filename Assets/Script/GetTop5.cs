using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetTop5 : MonoBehaviour
{
    public Text[] top5;
    // Start is called before the first frame update
    private void OnValidate()
    {
        top5 = GetComponentsInChildren<Text>();
    }

    private void Start()
    {
        SaveRankManager.LoadDataToRankData();
        string[] scores = SaveRankManager.GetRankData();
        for (int i = 0; i < 5; i++)
        {
            top5[i].text = scores[i];
        }
    }

}
