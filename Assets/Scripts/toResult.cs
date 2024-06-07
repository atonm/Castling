using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class toResult : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //エンターでリザルトへ
         if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Result");   
        }
    }
}
