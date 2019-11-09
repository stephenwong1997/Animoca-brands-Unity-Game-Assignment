using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionArea : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            float thisScore = float.Parse(GetComponentInChildren<TextMesh>().text);
            float ballMultiplier = other.GetComponent<BallStats>().multipler;
            GameManager.Instance.AddScore((int)(thisScore*ballMultiplier));
        }
    }
}
