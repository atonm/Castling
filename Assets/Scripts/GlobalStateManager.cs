/*
 * Copyright (c) 2017 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#define TEST

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GlobalStateManager : MonoBehaviour
{
    private int deadPlayers = 0;    //死亡したプレイヤーの数
    private int deadPlayerNumber = -1;  //死亡したプレイヤーの番号

    private float step_time = 0.0f;    // 経過時間カウント用

    //爆弾管理用配列
    private List<GameObject> bombObjects = new List<GameObject>();

    public void Start()
    {
        // 死亡数リセット
        Player.ndead1 = 0;
        Player.ndead2 = 0;
        Player.ndead3 = 0;
        Player.ndead4 = 0;
    }

    public void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 数秒後に画面遷移（リザルトへ移動）
        if(step_time >= 60.0f)
        {
            SceneManager.LoadScene("roles");
            //StartCoroutine(StopTime());     // 15秒止める
        }
    }

    //IEnumerator StopTime()
    //{
    //    // 15秒待つ
    //    yield return new WaitForSeconds(15);

    //    // 再開してから実行する処理
    //    SceneManager.LoadScene("Result");
    //}

    public int NumberofBombObjects(int playerNumber)
    {
        int count = 0;
        foreach(GameObject go in bombObjects)
        {
            //爆弾のスクリプトを取得して、爆弾を設置したプレイヤーの情報を取得する
            if (go.GetComponent<Bomb>()?.installationPlayernumber==playerNumber)
            {
            
            //指定したプレイヤーが設置した爆弾
            count++;
            }
        }
        
        return count;
    }

    // 爆弾管理用配列のクリア
    public void ClearAllBombs()
    {
        bombObjects.Clear();
    }

    //爆弾管理用配列に爆弾のGameObjectを追加
    public void AddBombObject(GameObject gameObject)
    {
        bombObjects.Add(gameObject);
    }

    //爆弾管理配列から爆弾のGameObjectを削除
    public void RemoveBombObject(GameObject gameObject)
    {
        bombObjects.Remove(gameObject);
    }

    //指定された位置に既に爆弾が配置済みか？
    public bool BombObjectExists(Vector3 pos)
    {
        foreach (GameObject go in bombObjects)
        {
            if (go.transform.position.Equals(pos))
            {
                return true;
            }
        }

        return false;
    }

    public void PlayerDied (int playerNumber)
    {
        //死亡したプレイヤーの数を増やす
        deadPlayers++;

        if (deadPlayers == 1)
        {
            //死亡したプレイヤーの番号を保持し、
            deadPlayerNumber = playerNumber;

            //0.3秒後に CheckPlayersDeath 関数を呼び出す
            Invoke("CheckPlayersDeath",0.3f);
        }
    }

    void CheckPlayersDeath()
    {
#if !TEST
        //死亡したプレイヤーが　1人だけの場合
        if (deadPlayers == 1)
        {
            if (deadPlayerNumber == 1)
            {
                //プレイヤー2が勝利した
                Debug.Log("プレイヤー2　の勝利！");


                //シーンを2秒後にrolesシーンに移動
                Invoke("LoadScene", 2f);

            }
            else
            {
                //プレイヤー1が勝利した
                Debug.Log("プレイヤー1　の勝利！");


                //シーンを2秒後にrolesシーンに移動
                Invoke("LoadScene", 2f);
            }
        }
        else 
        {
            //引き分け
            Debug.Log("引き分け");
            //シーンを2秒後にrolesシーンに移動
            Invoke("LoadScene", 2f);
        }
#endif
    }


    void LoadScene()
    {
        SceneManager.LoadScene("roles");
    }
}
