using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass {
        
        private Text textHolder;

        [Header ("Text Options: ")]
        [SerializeField]private string input;
        [SerializeField]private Color textColor;
        [SerializeField]private Font textFont;


        //[Header ("Time parameters: ")]
        //[SerializeField]private float delay;

        private void Awake ()
        {
            textHolder = GetComponent<Text>();
           //StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay));
            StartCoroutine(WriteText(input, textHolder, textColor, textFont));
            // StartCoroutine(WriteText(input, textHolder));
        }
}


}