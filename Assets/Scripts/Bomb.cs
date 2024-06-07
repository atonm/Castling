using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    //���e��ݒu�����v���C���[�̔ԍ�
    public int installationPlayernumber = -1;
    public LayerMask levelMask;
    private bool explode=false; //���ɔ������Ă���ꍇ true
    public GameObject explosionPrefab;  //�����G�t�F�N�g�̃v���t�@�u

    //�A�C�e���ŋ����O�̔��e�̈З�
    [Range(1, 10)]
    public int bombPower=3;

    //�������ɌĂяo���f���Q�[�g
    //UnityEvent�ŏ�����o�^��������ɕύX���܂���
    public UnityEvent<GameObject> onExplodedhandler=null;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 3f);
    }

    private void Explode()
    {
        // ���e�̈ʒu�ɔ����G�t�F�N�g���쐬
        Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);

        //�������̃n���h���Ăяo��
        onExplodedhandler.Invoke(gameObject);

        // ���e���\���ɂ���
        this.GetComponent<MeshRenderer>().enabled = false;
       //��������
        explode=true;
        StartCoroutine(CreateExplosion(Vector3.forward));
        StartCoroutine(CreateExplosion(Vector3.right));
        StartCoroutine(CreateExplosion(Vector3.back));
        StartCoroutine(CreateExplosion(Vector3.left));
        this.transform.Find("Collider").gameObject.SetActive(false);

        // 0.3 �b��ɔ�\���ɂ������e���폜
        Destroy(this.gameObject, 0.3f);
    }

    private IEnumerator CreateExplosion(Vector3 direction)
    {
        // 2 �}�X�����[�v����
        for (int i = 0; i < bombPower; i++)
        {
            RaycastHit hit;

            // �������L������ɉ������݂��邩�m�F
            Physics.Raycast
                (
               transform.position + new Vector3(0, 0.5f, 0),
               direction,
               out hit,
               i,
               levelMask
                );

            // �������L������ɉ������݂��Ȃ��ꍇ
            if (!hit.collider)
            {
                // �������L���邽�߂ɁA
                // �����G�t�F�N�g�̃I�u�W�F�N�g���쐬
                Instantiate
                    (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                    );
            }
            // �������L������Ƀu���b�N�����݂���ꍇ
            else
            {
                // �����͂���ȏ�L���Ȃ�
                break;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //�܂��������Ă��Ȃ�
        //���A���̔����ɂԂ������I�u�W�F�N�g�������G�t�F�N�g�̏ꍇ
        if (!explode&&other.CompareTag("Explosion"))
        {
            //2�d�ɔ������������s����ɂ��p��
            //���łɔ������������s����Ă���ꍇ�͎~�߂�
            CancelInvoke("Explode");

            //��������
            Explode();
        }
    
    }
}
