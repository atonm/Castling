using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class role12_image : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Image Image12;
    public Sprite intro21;
    public Sprite intro22;
    public static int randomNo12; 

     public static int getRole12()//1P2Pの役割を決める
    {
        return randomNo12;
    }

    // Start is called before the first frame update
    void Start()
    {
        randomNo12 = Random.Range(1,3);//どのパターンの画像を使うか決定
        Debug.Log("キング12" + randomNo12);

        // 画像を表示
        string imgStr = "intro2" + randomNo12;
        Sprite image = Resources.Load<Sprite> (imgStr);
        Image12.sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        //エンターで次の画面へ
       if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("12don't_look");   
        }
    }
}
