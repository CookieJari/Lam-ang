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


        [Header ("Time parameters: ")]
        [SerializeField]private float delay;
        [SerializeField]private float delayBetweenLines;

        [Header ("Sound: ")]
        [SerializeField]private AudioClip sound;


        [Header ("Character Image: ")]
        [SerializeField]private Sprite characterSprite;
        [SerializeField]private Image imageHolder;


        private void Awake ()
        {
           textHolder = GetComponent<Text>();
           // Make text empty
            textHolder.text = "";

           imageHolder.sprite = characterSprite;
           imageHolder.preserveAspect = true;

        }

        private void Start()
        {
           StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines));
        }

}


}