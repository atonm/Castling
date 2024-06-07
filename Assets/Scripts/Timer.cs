using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timertext;

    // ���Ԃ�\������p
    private float second;
    private float timer_num;

    // Start is called before the first frame update
    void Start()
    {
        timertext = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;

        timer_num = 300 - second;

        // ���ԕ\���i�����_�ȉ��؂�̂āj
        timertext.text = Mathf.Floor(timer_num).ToString();
    }
}
