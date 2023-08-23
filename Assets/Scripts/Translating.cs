using UnityEngine;
using UnityEngine.UI;

public class Translating : MonoBehaviour
{
    [SerializeField] private Text text; 
    
    public void TranslateText()
    {
        text.text = "Natives: Welcome to our planet";
    }
}
