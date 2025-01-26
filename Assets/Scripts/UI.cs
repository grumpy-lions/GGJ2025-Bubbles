using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{

    [SerializeField] TMP_Text TimeLabel;
    [SerializeField] TMP_Text PointsLabel;
    [Range(0f, 60)] 
    [SerializeField] float UpdateThresh = 1f;
    [Range(1, 100)] 
    [SerializeField] int PointMod = 10;
    // Start is called before the first frame update
    void Start()
    {
        PointsLabel.text = "0 pts";
        TimeLabel.text = "00:00.00";
    }

    float TimeElapsed;
    int Points;
    float UpdateTime;
    // Update is called once per frame Resources/unity_builtin_extra
    void Update()
    {
        if (!Buttons.DEAD) {
        TimeElapsed += Time.deltaTime;
        UpdateTime += Time.deltaTime;
        TimeLabel.text = $"{((int)TimeElapsed/60).ToString().PadLeft(2, '0')}:{((int)TimeElapsed % 60).ToString().PadLeft(2, '0')}";

        if(UpdateTime > UpdateThresh) {
            Points += PointMod * Spawner.Spawned;
            UpdateTime = 0;
        }

        PointsLabel.text = $"{Points} pts";
        }
    }
}
