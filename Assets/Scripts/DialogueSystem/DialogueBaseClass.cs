/*
 * Title: Biag ni Lam-ang -  A platformer game about the Ilokano Folklore of Biag ni Lam-ang
 * 
 * Programmers:  Asher Manangan
 * 
 * Sub-System: Dialogue system
 * 
 * Date written: August 23, 2022    Date Revised: November 4, 2023
 * 
 * Purpose: Handles the Diaologue system
 * 
 * Data Structures, algorithms, and control: Arrays,
 * 
 * */

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; protected set; }

        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound, float delayBetweenLines)
        {
            textHolder.color = textColor;
            textHolder.font = textFont;

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                // play text sound
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }

            //yield return new WaitForSeconds(delayBetweenLines);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.E));
            finished = true;
        }
    }
}