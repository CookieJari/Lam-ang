using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;
        private bool dialogueFinished = false;
        private bool dialogueRepeat = false;

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
            if (dialogueFinished==false && dialogueRepeat==false)
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

            if (dialogueFinished==false && dialogueRepeat==true )
            {
                for (int i = transform.childCount-1; i < transform.childCount ; i++)
                {
                    Deactivate();
                    transform.GetChild(i).gameObject.SetActive(true);
                    yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
                }
            dialogueFinished = true;
            gameObject.SetActive(false);
            }


            if(dialogueFinished==true)
            {
                   
                Deactivate();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
                Invoke("dialogueFinishedFalse", 0.5f);
                
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
            dialogueRepeat = true;
        }
    }
}