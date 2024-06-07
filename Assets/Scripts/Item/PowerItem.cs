using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PowerItem : MonoBehaviour, IGetItem
{
    //�A�C�e���ŋ������̔��e�̈З�
    [SerializeField,Range(1, 10)]
    private int bombPowerUp = 4;

    private AudioSource _soundManeger;
    [Header("�����������ʉ�"), SerializeField]
    private AudioClip _SeClip;

    /// <summary>
    /// ���e�̈З͂��グ��
    /// </summary>
    public void GetItem(GameObject gameObject)
    {
        //try
        {
            Debug.Log($"{this.gameObject.name}�A�C�e�����Q�b�g���܂���");

            //�A�C�e���������ʉ��𗬂�
            var player = gameObject.GetComponent<Player>();
            _soundManeger = this.gameObject.GetComponent<AudioSource>();
            _soundManeger?.PlayOneShot(_SeClip);

            //���e�̈З͂��オ��
            if (player != null)
            {
                player.bombPlayerPower = bombPowerUp;
            }

            //�I�u�W�F�N�g�j�󃁃\�b�h�͏d�����̂ŁA���A�N�e�B�u���\�b�h�őΉ�
            //Destroy�őΉ����Ă��ꉞ�����v�ł�
            //this.gameObject.SetActive(false);
            this.GetComponent<MeshRenderer>().enabled = false;


            //���𗬂����߂ɂP�b�҂��āA�j�󂷂�
            Destroy(this.gameObject, 1.0f);
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
