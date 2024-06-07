using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour���p�������V���O���g���ȃN���X�i���N���X�j
/// </summary>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// �C���X�^���X
    /// </summary>
    private static T _instance;

    /// <summary>
    /// �C���X�^���X�̃Q�b�^�[
    /// </summary>
    public static T Instance
    {
        get
        {
            //�C���X�^���X��null�`�F�b�N(����N����)
            if (_instance == null)
            {
                T[] instances = null;
                instances = FindObjectsOfType<T>();
                //FindObjectOfType(typeof(T)) as T; �@������ő��v�ł�

                //�C���X�^���X�����݂Ȃ�
                if (instances.Length == 0)
                {
                    Debug.LogError(typeof(T) + "�C���X�^���X�͂���܂���B�A�^�b�`���Y��Ă��܂��񂩁H");
                    return null;
                }
                //�C���X�^���X���������݂��Ă���...
                else if (instances.Length >= 2)
                {
                    Debug.LogError(typeof(T) + "�C���X�^���X��������������Ă��܂��B");
                    return null;
                }
                //�C���X�^���X��1���݂��Ă���(����)
                else
                {
                    _instance = instances[0];
                    Debug.Log(typeof(T) + "�C���X�^���X��1��������Ă��܂��B����ł��B");
                }
            }

            return _instance;
        }
    }
}