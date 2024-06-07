using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultTex1 : MonoBehaviour
{
    private TextMeshProUGUI num_text;
    private int player2;
    int King12 = role12_image.getRole12();

    // Start is called before the first frame update
    void Start()
    {
        // ƒ‹[ƒN‚Ì€–S”‚ğæ“¾
        switch (King12)
        {
            case 1:
                player2 = Player.ndead2;
                break;
            case 2:
                player2 = Player.ndead1;
                break;
        }

        num_text = GetComponent<TextMeshProUGUI>();
        num_text.text = player2.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
