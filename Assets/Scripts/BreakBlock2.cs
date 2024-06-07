using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock2 : MonoBehaviour
{
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
            Debug.Log("ブロックが壊れた！");

            // ブロックを削除
            Destroy(gameObject);
        }
    }
}
