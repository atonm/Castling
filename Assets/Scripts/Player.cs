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

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    //Player parameters
    [Range(1, 4)] //Enables a nifty slider in the editor
    public int playerNumber = 1;
    //Indicates what player this is: P1 or P2
    public bool canDropBombs = true;
    //Can the player drop bombs?
    public bool canMove = true;
    //Can the player move?
    public bool dead = false;//死亡した場合true
    //ゲームの状態を管理するスクリプト
    GameObject globalManager;
    GlobalStateManager gmScript;

    //Amount of bombs the player has left to drop, gets decreased as the player
    //drops a bomb, increases as an owned bomb explodes

    //Prefabs
    public GameObject bombPrefab;
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject player3Prefab;
    public GameObject player4Prefab;

    //Cached components
    private Rigidbody rigidBody;
    private Transform myTransform;
    private Animator animator;

    // プレイヤーの位置取得用
    private Vector3 obj1;
    private Vector3 obj2;
    private Vector3 obj3;
    private Vector3 obj4;

    // 無敵時間用
    private float mutekiFlag = 0;
    private float mutekiTime = 150;

    // 死亡回数カウント
    public static int ndead1 = 0;
    public static int ndead2 = 0;
    public static int ndead3 = 0;
    public static int ndead4 = 0;

    //プレイの歩く速度を反映させる
    public float moveSpeed = 4f;
    //所持できる爆弾の数
    public int bombs = 2;
    //プレイヤーそれぞれが持つ爆弾の威力
    public int bombPlayerPower = 3;

    // Use this for initialization
    void Start()
    {
        //Cache the attached components for better performance and less typing
        rigidBody = GetComponent<Rigidbody>();
        myTransform = transform;
        animator = myTransform.Find("PlayerModel").GetComponent<Animator>();

        globalManager = GameObject.Find("Global State Manager");
        gmScript = globalManager.GetComponent<GlobalStateManager>();

        // 初期位置の取得
        obj1 = GameObject.Find("Player 1").transform.position;
        obj2 = GameObject.Find("Player 2").transform.position;
        obj3 = GameObject.Find("Player 3").transform.position;
        obj4 = GameObject.Find("Player 4").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 無敵時間の処理
        if(mutekiFlag == 1)
        {
            mutekiTime--;
            if(mutekiTime < 0)
            {
                mutekiFlag = 0;
                mutekiTime = 150;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("roles");
        }

        UpdateMovement();
    }

    private void UpdateMovement()
    {
        animator.SetBool("Walking", false);

        if (!canMove)
        { //Return if player can't move
            return;
        }

        if(playerNumber == 1)
        {
            UpdatePlayer1Movement();
        }
        if(playerNumber == 2)
        {
            UpdatePlayer2Movement();
        }
        if(playerNumber == 3)
        {
            UpdatePlayer3Movement();
        }
        if(playerNumber == 4)
        {
            UpdatePlayer4Movement();
        }
    }

    /// <summary>
    /// Updates Player 1's movement and facing rotation using the WASD keys and drops bombs using X key
    /// </summary>
    private void UpdatePlayer1Movement()
    {
        if (Input.GetKey(KeyCode.W))
        { //Up movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.A))
        { //Left movement
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.S))
        { //Down movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.D))
        { //Right movement
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

        if (canDropBombs && Input.GetKeyDown(KeyCode.X))
        { //Drop bomb
            DropBomb();
        }
    }
    
    /// <summary>
    /// Updates Player 2's movement and facing rotation using the TFGH keys and drops bombs using Space
    /// </summary>
    private void UpdatePlayer2Movement()
    {
        if (Input.GetKey(KeyCode.T))
        { //Up movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.F))
        { //Left movement
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.G))
        { //Down movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.H))
        { //Right movement
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

        if (canDropBombs && Input.GetKeyDown(KeyCode.Space))
        { //Drop bomb
            DropBomb();
        }
    }

    /// <summary>
    /// Updates Player 3's movement and facing rotation using the IJKL keys and drops bombs using M key
    /// </summary>
    private void UpdatePlayer3Movement()
    {
        if (Input.GetKey(KeyCode.I))
        { //Up movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.J))
        { //Left movement
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.K))
        { //Down movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.L))
        { //Right movement
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

        if (canDropBombs && (Input.GetKeyDown(KeyCode.M)))
        { //Drop Bomb. For Player 3's bombs, allow both the numeric M key or players 
            //without a numpad will be unable to drop bombs
            DropBomb();
        }
    }
    
    /// <summary>
    /// Updates Player 4's movement and facing rotation using the arrow keys and drops bombs using Enter or Return
    /// </summary>
    private void UpdatePlayer4Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        { //Up movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        { //Left movement
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        { //Down movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        { //Right movement
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

        if (canDropBombs && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
        { //Drop Bomb. For Player 4's bombs, allow both the numeric enter as the return key or players 
            //without a numpad will be unable to drop bombs
            DropBomb();
        }
    }

    /// <summary>
    /// Drops a bomb beneath the player
    /// </summary>
    private void DropBomb()
    {
       
        if (bombPrefab)
        { //Check if bomb prefab is assigned first

            var pos = new Vector3(
            Mathf.RoundToInt(myTransform.position.x),
           bombPrefab.transform.position.y,
           Mathf.RoundToInt(myTransform.position.z)
            );

            //同時に設置できる数を制限する
            if (gmScript.NumberofBombObjects(playerNumber) >= bombs)
            {
                //bombs個以上設置していたら新たに設置できない
                return;
            }

            // 既に配置済みの場合は、同じ場所に配置禁止
            if (gmScript.BombObjectExists(pos) == true)
            {
                return;
            }

            //爆弾のゲームオブジェクトを作成
            var bombGameobject = Instantiate(bombPrefab, pos,bombPrefab.transform.rotation);
            bombGameobject.GetComponent<Bomb>().installationPlayernumber = playerNumber;

            //Instantiate(bombPrefab, pos, bombPrefab.transform.rotation);

            var script = bombGameobject.GetComponent<Bomb>();
            if (script != null)
            {
                //爆弾が爆発したら、爆弾管理配列から削除
                script.onExplodedhandler.AddListener((go) => {
                    gmScript.RemoveBombObject(go);
                    });
            }

            //爆弾が生成された時に、プレイヤーに応じた爆弾の威力を設定する
            script.bombPower = bombPlayerPower;

            //爆弾管理配列に追加
            gmScript.AddBombObject(bombGameobject);
        }
    }

    public  int count;

    private void Awake()
    {
        count = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        //オブジェクトの衝突確認(デバッグ)
        //Debug.Log(other.gameObject.name + "が衝突したで");
        //アイテム衝突したらIGetItemインターフェースを取り込んで
        var hit = other.gameObject.GetComponent<IGetItem>();
        //それぞれのアイテムに定義されている処理を呼び出す
        hit?.GetItem(this.gameObject);

        globalManager = GameObject.Find("Global State Manager");
        gmScript = globalManager.GetComponent<GlobalStateManager>();

        if (other.CompareTag("Explosion") && mutekiFlag == 0)
        {
            mutekiFlag = 1;
            //Debug.Log("P" + playerNumber + " hit by explosion!");

            //死亡した
            dead = true;

            //ゲームの状態を管理するスクリプトに
            //死亡したプレイヤーの番号を通知
            gmScript.PlayerDied(playerNumber);

            // プレイヤーを初期位置に移動
            if (dead)
            {
                dead = false;
                if (playerNumber == 1)
                {
                   gameObject.transform.position = obj1;   // プレイヤーを初期位置にする
                   ndead1 += 1;                            // プレイヤーの死亡回数のカウント
                   ScoreShare.Instance.OverrideValue(ndead1,1);
                }
                if (playerNumber == 2)
                {
                    gameObject.transform.position = obj2;   // プレイヤーを初期位置にする
                    ndead2 += 1;                            // プレイヤーの死亡回数のカウント
                    ScoreShare.Instance.OverrideValue(ndead2,2);
                }
                if (playerNumber == 3)
                {
                    gameObject.transform.position = obj3;   // プレイヤーを初期位置にする
                    ndead3 += 1;                            // プレイヤーの死亡回数のカウント
                    ScoreShare.Instance.OverrideValue(ndead3,3);
                }
                if (playerNumber == 4)
                {
                    gameObject.transform.position = obj4;   // プレイヤーを初期位置にする
                    ndead4 += 1;                            // プレイヤーの死亡回数のカウント
                    ScoreShare.Instance.OverrideValue(ndead4,4);
                }
                Debug.Log("1" + ndead1);
                //Debug.Log("2" + ndead2);
                //Debug.Log("3" + ndead3);
                //Debug.Log("4" + ndead4);
            }
        }
    }
}
