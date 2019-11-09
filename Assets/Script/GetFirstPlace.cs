using UnityEngine;
using UnityEngine.UI;

public class GetFirstPlace : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SaveRankManager.LoadDataToRankData();
        GetComponent<Text>().text = SaveRankManager.GetFirstPlaceData();
    }

}
