using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class dont_look34 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //エンターで1,2プレイヤーの役割画面へ  
         if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("role12");   
        }
}}
