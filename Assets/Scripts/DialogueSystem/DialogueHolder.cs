using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;
        private bool dialogueFinished;

        private void OnEnable()
        {
            dialogueSeq = dialogueSequence();
            StartCoroutine(dialogueSeq);
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Deactivate();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
            }
        }

        private IEnumerator dialogueSequence()
        {
            if (!dialogueFinished)
            {
                for (int i = 0; i < transform.childCount ; i++)
                {
                    Deactivate();
                    transform.GetChild(i).gameObject.SetActive(true);
                    yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
                }
            dialogueFinished = true;
            gameObject.SetActive(false);
            }

            else
            {
                   
                Deactivate();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
                Invoke("dialogueFinishedFalse", 1.0f);
                
            }


        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        void dialogueFinishedFalse(){
            dialogueFinished = false;
        }
    }
}