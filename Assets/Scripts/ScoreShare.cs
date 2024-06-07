using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreShare : SingletonMonoBehaviour<ScoreShare>
{
    #region Singleton

    private void Awake()
    {
        if (this != Instance)
        {
            Debug.LogError("�C���X�^���X�����ɑ��݂��Ă��܂��B�C���X�^���X����ɂ��邽�߂��̃C���X�^���X��j�����܂�");
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    public int player1count { get; private set; } = 0;
    public  int player2count { get; private set; } = 0;
    public  int player3count { get; private set; } = 0;
    public  int player4count { get; private set; } = 0;

    /// <summary>
    /// ���S�񐔂��㏑������
    /// </summary>
    /// <param name="count">���񂾉�</param>
    /// <param name="number">�v���C���[�̔ԍ�</param>
    public void OverrideValue(int count,int number)
    {

        if (number == 1)
        {
            Instance.player1count = count;
            Debug.Log(Instance.player1count);
        }
        else if (number == 2)
        {
            Instance.player2count = count;
        }
        else if (number == 3)
        {
            Instance.player3count = count;
        }
        else {
            Instance.player4count = count;
        }

    }
}
