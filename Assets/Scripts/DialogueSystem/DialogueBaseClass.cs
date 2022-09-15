using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace DialogueSystem
{

    
public class DialogueBaseClass : MonoBehaviour 
{
    protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound)

    {
         textHolder.color = textColor;
         textHolder.font = textFont;

        for (int i = 0; i < input.Length; i++)
        {
            textHolder.text += input[i];

            SoundManager.instance.PlaySound(sound);
            yield return new WaitForSeconds(delay);

        }
    }
} // End of MonoBehavior

} // End of Namespace

