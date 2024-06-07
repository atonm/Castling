using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
   public void Update()
    {
        //エンターでルール説明画面へ
         if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Rule");   
        }
    }
   
}
