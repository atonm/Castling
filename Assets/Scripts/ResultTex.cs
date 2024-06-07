using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultTex : MonoBehaviour
{
    private TextMeshProUGUI num_text;
    private int player1;
    int King12 = role12_image.getRole12();

    // Start is called before the first frame update
    void Start()
    {
        // ƒLƒ“ƒO‚Ì€–S”‚ğæ“¾
        switch (King12)
        {
            case 1:
                player1 = Player.ndead1;
                break;
            case 2:
                player1 = Player.ndead2;
                break;
        }

        num_text = GetComponent<TextMeshProUGUI>();
        num_text.text = player1.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
