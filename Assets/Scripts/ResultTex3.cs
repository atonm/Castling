using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultTex3 : MonoBehaviour
{
    private TextMeshProUGUI num_text;
    private int player4;
    int King34 = role34_image.getRole34();

    // Start is called before the first frame update
    void Start()
    {
        // ���[�N�̎��S�����擾
        switch (King34)
        {
            case 1:
                player4 = Player.ndead4;
                break;
            case 2:
                player4 = Player.ndead3;
                break;
        }

        Debug.Log("���[�N���S��" + player4);

        num_text = GetComponent<TextMeshProUGUI>();
        num_text.text = player4.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
