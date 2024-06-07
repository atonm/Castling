using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreakBlock : MonoBehaviour
{
    public GameObject ItemPrefab;   // �A�C�e���̃v���n�u���擾

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
            //Debug.Log("�u���b�N����ꂽ�I");

            // �A�C�e���̃Q�[���I�u�W�F�N�g�̍쐬
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(ItemPrefab, pos, Quaternion.identity);

            // �u���b�N���폜
            Destroy(gameObject);
        }
    }
}
