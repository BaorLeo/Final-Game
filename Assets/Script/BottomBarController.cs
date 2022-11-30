using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static StoryScene;
using UnityEngine.UI;
using System;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    private StoryScene currentSecne;
    private State state = State.COMPLETED;
    private Animator animator;
    private bool isHidden = false;
    public List<Image> listPlayerImages;
    public Sentence sentence;

    private enum State
    {
        PLAYING , COMPLETED
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Hide()
    {
        if(!isHidden)
        { 
            animator.SetTrigger("Hide");
            isHidden = true;
            listPlayerImages[sentence.charactorImage].gameObject.SetActive(false);
        }
    }
    public void Show()
    {
        animator.SetTrigger("Show");
        isHidden = false;
        listPlayerImages[sentence.charactorImage].gameObject.SetActive(true);
    }

    public void ClearText()
    {
        barText.text = "";
    }
    public void PlayScene(StoryScene scene)
    {
        Debug.Log("PLAY");
        currentSecne = scene;
        sentenceIndex =-1;
        PlayNextSentence();
    }

    
   public  void PlayNextSentence()
    {
      //  Debug.Log(currentSecne.sentences[++sentenceIndex].text);

        StartCoroutine(TypeText(currentSecne.sentences[++sentenceIndex]));
        personNameText.text = currentSecne.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentSecne.sentences[sentenceIndex].speaker.textColor;
    }
    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }
    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentSecne.sentences.Count;
    }
   private IEnumerator TypeText(Sentence sentence)
    {
        Debug.Log("type " + sentence.text);
        barText.text = "";//Cho phep tam dung giua cac dau ra cua ca chu cai , dieu nay se tao hieu ung danh may
        state = State.PLAYING;
        int wordIndex = 0; //Cho phep tam dung giua cac dau ra cua ca chu cai , dieu nay se tao hieu ung danh may
        Debug.Log(sentence.charactorImage);
        for(int i=0;i < listPlayerImages.Count;i++)
        {
            listPlayerImages[i].gameObject.SetActive(false);
        }
        listPlayerImages[sentence.charactorImage].gameObject.SetActive(true);
        while (state != State.COMPLETED)
        {
            barText.text += sentence.text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if(++wordIndex == sentence.text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
