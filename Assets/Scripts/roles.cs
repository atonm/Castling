using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class roles : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Image Roles;
    public Sprite result11;
    public Sprite result12;
    public Sprite result21;
    public Sprite result22;

    //public int role12 = role12_image.getRole12();
    //public int role34 = role34_image.getRole34();

    string imgStr = null;
    // キング取得
    int King12 = role12_image.getRole12();//1Pがキング＝１、２Pがキング＝２
    int King34 = role34_image.getRole34();//３Pがキング＝１、４Pがキング＝２

    // Start is called before the first frame update
    void Start()
    {
        GameObject image_result = GameObject.Find("Roles");
        Image image = image_result.GetComponent<Image>();

        //各チームのキングを取得
        //十の位が1P2P、一の位が3P4P
        int n = King12 * 10 + King34;
        //int n = role12 * 10 + role34;

        // 画像を選択
        // 割り当てた番号で選ぶ
        switch (n)
        {
            case 11:
                imgStr = result11.name;
                break;
            case 12:
                imgStr = result12.name;
                break;
            case 21:
                imgStr = result21.name;
                break;
            case 22:
                imgStr = result22.name;
                break;
        }

        // テクスチャの表示
        //Texture2D texture = Resources.Load(imgStr) as Texture2D;
        //image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        // 画像を表示
        //string imgStr = "result" + role12 + role34;
        Sprite roleimage = Resources.Load<Sprite> (imgStr);
        Roles.sprite = roleimage;
    }

    // Update is called once per frame
    void Update()
    {
        //エンターで次の画面へ
       if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Killed");   
        }
    }
}
