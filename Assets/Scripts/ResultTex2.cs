using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultTex2 : MonoBehaviour
{
    private TextMeshProUGUI num_text;
    private int player3;
    int King34 = role34_image.getRole34();

    // Start is called before the first frame update
    void Start()
    {
        // ƒLƒ“ƒO‚Ì€–S”‚ğæ“¾
        switch (King34)
        {
            case 1:
                player3 = Player.ndead3;
                break;
            case 2:
                player3 = Player.ndead4;
                break;
        }

        num_text = GetComponent<TextMeshProUGUI>();
        num_text.text = player3.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
