using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public GameObject Ball;
    public Slider PowerSlider;
    private GameObject temBall;
    private bool Clicking = false;
    private int poweringSpeed;
    public int maxRollPower = 13;

    private float[] multiplierNum = { 1.0f, 1.5f ,2.0f ,2.5f};
    private int[] massNum = { 10, 20, 30 };
    // Update is called once per frame

    private void OnValidate()
    {
        PowerSlider.maxValue = maxRollPower;
  
    }
    private void Start()
    {
        //temBall = new GameObject("initBall");
        //temBall.transform.position = Camera.main.transform.position + new Vector3(100, 100, 100);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(temBall)
            if(Vector3.Distance(temBall.transform.position, Camera.main.transform.position) < 5f)
            {
                return;
            }
            Clicking = true;
            temBall = Instantiate(Ball);
            InitBall();
            PowerSlider.value = 0;
            poweringSpeed = 1;
        }
        if (Clicking)
        {
            PowerSliderLoop();
            temBall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane *5));

            if (Input.GetButtonUp("Fire1"))
            {

                ReleaseBall();
                Clicking = false;
            }
        }   
    }

    private GameObject InitBall()
    {
        temBall.GetComponent<Rigidbody>().useGravity = false;
        temBall.GetComponent<BallStats>().multipler = multiplierNum[(int)Random.Range(0, multiplierNum.Length)];
        temBall.GetComponentInChildren<TextMesh>().text = temBall.GetComponent<BallStats>().multipler + "X";
        return temBall;
    }

    private void PowerSliderLoop()
    {
        PowerSlider.value += (PowerSlider.value * 2.5f + PowerSlider.maxValue * 0.2f) * Time.deltaTime * poweringSpeed;

        if (Mathf.Approximately(PowerSlider.value, PowerSlider.maxValue) || Mathf.Approximately(PowerSlider.value, PowerSlider.minValue))
        {
            poweringSpeed *= -1;
        }
    }
    private void ReleaseBall()
    {
        temBall.GetComponent<Rigidbody>().useGravity = true;
        temBall.GetComponent<Rigidbody>().AddForce(new Vector3(PowerSlider.value, PowerSlider.value / 3, 0));
        temBall.GetComponent<Rigidbody>().mass = massNum[(int)Random.Range(0, massNum.Length)];
        PowerSlider.value = PowerSlider.minValue;
        Destroy(temBall, 5f);

    }

    public void OnGameEnd()
    {
        if (Clicking)
        {
            ReleaseBall();
            Clicking = false;
        }
    }
}
