using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace DialogueSystem
{

    
public class DialogueBaseClass : MonoBehaviour 
{
   // protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay)
    protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont)
    //protected IEnumerator WriteText(string input, Text textHolder)
    {
         textHolder.color = textColor;
         textHolder.font = textFont;

        for (int i = 0; i < input.Length; i++)
        {
            textHolder.text += input[i];
            yield return new WaitForSeconds(0.1f);

        }
    }
} // End of MonoBehavior

} // End of Namespace


