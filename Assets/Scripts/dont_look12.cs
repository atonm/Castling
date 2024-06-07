using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class dont_look12 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //エンターで3,4プレイヤーの役割画面へ
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("role34");   
        }
    }
}
