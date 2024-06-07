using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    //爆弾を設置したプレイヤーの番号
    public int installationPlayernumber = -1;
    public LayerMask levelMask;
    private bool explode=false; //既に爆発している場合 true
    public GameObject explosionPrefab;  //爆発エフェクトのプレファブ

    //アイテムで強化前の爆弾の威力
    [Range(1, 10)]
    public int bombPower=3;

    //爆発時に呼び出すデリゲート
    //UnityEventで処理を登録する方向に変更しました
    public UnityEvent<GameObject> onExplodedhandler=null;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 3f);
    }

    private void Explode()
    {
        // 爆弾の位置に爆発エフェクトを作成
        Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);

        //爆発時のハンドラ呼び出し
        onExplodedhandler.Invoke(gameObject);

        // 爆弾を非表示にする
        this.GetComponent<MeshRenderer>().enabled = false;
       //爆発した
        explode=true;
        StartCoroutine(CreateExplosion(Vector3.forward));
        StartCoroutine(CreateExplosion(Vector3.right));
        StartCoroutine(CreateExplosion(Vector3.back));
        StartCoroutine(CreateExplosion(Vector3.left));
        this.transform.Find("Collider").gameObject.SetActive(false);

        // 0.3 秒後に非表示にした爆弾を削除
        Destroy(this.gameObject, 0.3f);
    }

    private IEnumerator CreateExplosion(Vector3 direction)
    {
        // 2 マス分ループする
        for (int i = 0; i < bombPower; i++)
        {
            RaycastHit hit;

            // 爆風を広げた先に何か存在するか確認
            Physics.Raycast
                (
               transform.position + new Vector3(0, 0.5f, 0),
               direction,
               out hit,
               i,
               levelMask
                );

            // 爆風を広げた先に何も存在しない場合
            if (!hit.collider)
            {
                // 爆風を広げるために、
                // 爆発エフェクトのオブジェクトを作成
                Instantiate
                    (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                    );
            }
            // 爆風を広げた先にブロックが存在する場合
            else
            {
                // 爆風はこれ以上広げない
                break;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //まだ爆発していない
        //かつ、この爆発にぶつかったオブジェクトが爆発エフェクトの場合
        if (!explode&&other.CompareTag("Explosion"))
        {
            //2重に爆発処理が実行されにあ用に
            //すでに爆発処理が実行されている場合は止める
            CancelInvoke("Explode");

            //爆発する
            Explode();
        }
    
    }
}
