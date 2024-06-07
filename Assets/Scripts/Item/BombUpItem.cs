using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BombUpItem : MonoBehaviour,IGetItem
{
    //���������ꍇ�̏����ł����ő��̔��e��
    [SerializeField, Range(2, 10)]
    private int maxBombs = 6;
    //�������������e�̐�
    [SerializeField, Range(1, 4)]
    private int addBombs = 2;

    private AudioSource _soundManeger;
    [Header("�����������ʉ�"),SerializeField]
    private AudioClip _SeClip;

    /// <summary>
    /// ���e�̏��������グ��
    /// </summary>
    public void GetItem(GameObject gameObject)
    {
        //try
        {
            Debug.Log($"{this.gameObject.name}�A�C�e�����Q�b�g���܂���");

            //�A�C�e���������ʉ��𗬂�
            var player = gameObject.GetComponent<Player>();
            _soundManeger=this.gameObject.GetComponent<AudioSource>();
            _soundManeger?.PlayOneShot(_SeClip);

            //���e�ő及���������ݏ������Ă��锚�e�̐��𒴂��Ă��Ȃ��ꍇ
            if (player?.bombs < maxBombs)
            {
                Debug.Log($"���݂̔��e�̏�������{player.bombs + 2}�ł�");
                //�����ł��锚�e�̐��𑝂₷
                player.bombs += addBombs;
            }

            //�I�u�W�F�N�g�j�󃁃\�b�h�͏d�����̂ŁA���A�N�e�B�u���\�b�h�őΉ�
            //Destroy�őΉ����Ă��ꉞ�����v�ł�
            //this.gameObject.SetActive(false);
            this.GetComponent<MeshRenderer>().enabled = false;

            //���𗬂����߂ɂP�b�҂��āA�j�󂷂�
            Destroy(this.gameObject,1.0f);
        }
        //null���������Ă���
      /*  catch (NullReferenceException ex)
        {
            //�x�����b�Z�[�W���\������
            Debug.LogWarning($"�I�u�W�F�N�g��null�ł����\���������܂��B{this.name}�̎擾���\�b�h�Apublic���m�F���Ă��������B:{ex}");
        }
        //���\�b�h�̈�����null��������
        catch (ArgumentNullException ex)
        {
            //�x�����b�Z�[�W���\������
            Debug.LogWarning($"���\�b�h�̈�����null�ł��B{this.name}�ɂ��郁�\�b�h�̈������m�F���Ă��������B�F{ex}");
        }
        //���\�b�h�̈������s����������
        catch (ArgumentException ex)
        {
            //�x�����b�Z�[�W���\������
            Debug.LogWarning($"���\�b�h�̈������s���ł��B{this.name}�ɂ��郁�\�b�h�̈������m�F���Ă��������B�F{ex}");
        }
        //�����̗��O�Ƀq�b�g���Ȃ������ꍇ
        catch (Exception ex)
        {
            throw ex;
        }*/
    }
}
