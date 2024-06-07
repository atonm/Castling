using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//リザルト表示
[RequireComponent(typeof(AudioSource))]
public class DrawResult : MonoBehaviour
{
    [SerializeField]
    Text _king12TextScore;
    [SerializeField]
    Text _rook12TextScore;
    [SerializeField]
    Text _king34TextScore;
    [SerializeField]
    Text _rook34TextScore;

    private void Start()
    {
        if (role12_image.randomNo12==1)//1Pがキングの時
        {
            _king12TextScore.text = "Player1 : " + ScoreShare.Instance.player1count.ToString();//キング欄に１Pのやられた回数
            _rook12TextScore.text = "Player2 : " + ScoreShare.Instance.player2count.ToString();//ルーク欄に２Pのやられた回数
        }
        else//2Pがキングの時
        {
            _king12TextScore.text = "Player2 : " + ScoreShare.Instance.player1count.ToString();//キング欄に２Pのやられた回数
            _rook12TextScore.text = "Player1 : " + ScoreShare.Instance.player2count.ToString();//ルーク欄に１Pのやられた回数
        }
        
        if (role34_image.randomNo34==1)//３Pがキングの時
        {
            _king34TextScore.text = "Player3 : " + ScoreShare.Instance.player3count.ToString();//キング欄に３Pのやられた回数
            _rook34TextScore.text = "Player4 : " + ScoreShare.Instance.player4count.ToString();//ルーク欄に４Pのやられた回数
        }
        else//４Pがキングの時
        {
            _king34TextScore.text = "Player4 : " + ScoreShare.Instance.player4count.ToString();//キング欄に４Pのやられた回数
            _rook34TextScore.text = "Player3 : " + ScoreShare.Instance.player3count.ToString();//ルーク欄に３Pのやられた回数
        }
    }

}
