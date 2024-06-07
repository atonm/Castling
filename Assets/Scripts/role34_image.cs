using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class role34_image : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
     public Image Image34;
     public Sprite intro41;
     public Sprite intro42;
     public static int randomNo34;

     public static int getRole34()//3P4Pの役割を決める
    {
        return randomNo34;
    }

    // Start is called before the first frame update
    void Start()
    {
        randomNo34 = Random.Range(1,3);//どのパターンの画像を使うか決定
        Debug.Log("キング34" + randomNo34);

        // 画像を表示
        string imgStr = "intro4" + randomNo34;
        Sprite image = Resources.Load<Sprite> (imgStr);
        Image34.sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        //エンターで次の画面へ
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Game");   
        }
    }
}
