using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class toDontlook : MonoBehaviour
{
 

    void Update()
    {
        //エンターで役割発表へ
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("34don't_look");   
        }
    }
   

}