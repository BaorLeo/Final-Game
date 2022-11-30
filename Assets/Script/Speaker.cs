using UnityEngine;

[CreateAssetMenu(fileName ="NewSpaker", menuName = "Data/New Spaker")]
[System.Serializable]
public class Speaker : ScriptableObject // Mau ten chu
{
    public string speakerName;
    public Color textColor;
 /*   public FontStyle textFontStyle;*/
}
