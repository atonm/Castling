#define TEST

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{
    string imgStr = null;
    public Sprite winner12;
    public Sprite winner34;
    public Sprite winner1234;
    public static int winnernum;
    
    public Image Image;

    private int player1;
    private int player2;
    private int player3;
    private int player4;

    private int DeadKing12;
    private int DeadKing34;

    // Start is called before the first frame update
    void Start()
    {
        GameObject image_result = GameObject.Find("Result");

        // キング取得
        int King12 = role12_image.getRole12();
        int King34 = role34_image.getRole34();

#if !TEST
        // 死亡数を取得
        player1 = Player.ndead1;
        player2 = Player.ndead2;
        player3 = Player.ndead3;
        player4 = Player.ndead4;
#else
        // キングの死亡数を取得
        switch (King12)
        {
            case 1:
                DeadKing12 = Player.ndead1;
                break;
            case 2:
                DeadKing12 = Player.ndead2;
                break;
        }
        switch(King34)
        {
            case 1:
                DeadKing34 = Player.ndead3;
                break;
            case 2:
                DeadKing34 = Player.ndead4;
                break;
        }
#endif
        Debug.Log("比較用：" + DeadKing12);
        Debug.Log("比較用：" + DeadKing34);

        // キングの死亡数比較
        if(DeadKing12 == DeadKing34)
        {
            winnernum = 1234;
        }
        else if (DeadKing12 > DeadKing34)
        {
            winnernum = 34;
        }
        else
        {
            winnernum = 12;
        }

        Debug.Log("キング：" + winnernum);

        // 画像を選択
        switch (winnernum)
        {
            case 12:
                imgStr = winner12.name;
                break;
            case 34:
                imgStr = winner34.name;
                break;
            case 1234:
                imgStr = winner1234.name;
                break;
        }

        
        // 画像を表示
        Sprite resultimage = Resources.Load<Sprite> (imgStr);
        Image.sprite = resultimage;
    }


    // Update is called once per frame
    void Update()
    {
        //エンターでタイトルへ
       if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Title");
        }
    }
}
