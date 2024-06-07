using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class toExplanation : MonoBehaviour
{
 

   public void Update()
    {
        //エンターで操作説明画面へ
         if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Explanation");   
        }
    }
   
}
