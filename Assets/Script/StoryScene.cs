
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewStoryScene", menuName ="Data/New Story Scene")]
[System.Serializable]
public class StoryScene : ScriptableObject // chuyen canh va cau thoai
{
    public List<Sentence> sentences;
    public Sprite background;
    public StoryScene nextScene;
    [System.Serializable]
    public struct Sentence // Cau truc rieng biet danh cho cau thoai va nguoi doi thoai
    {
        public string text;
        public Speaker speaker;
        public int charactorImage;
    }
}
