using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreakBlock : MonoBehaviour
{
    public GameObject ItemPrefab;   // アイテムのプレハブを取得

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            //Debug.Log("ブロックが壊れた！");

            // アイテムのゲームオブジェクトの作成
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(ItemPrefab, pos, Quaternion.identity);

            // ブロックを削除
            Destroy(gameObject);
        }
    }
}
