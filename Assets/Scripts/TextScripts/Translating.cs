using UnityEngine;
using UnityEngine.UI;

namespace TextScripts
{
    public class Translating : MonoBehaviour
    {
        [SerializeField] private Text text; 
    
        public void TranslateText()
        {
            text.text = "Natives: Fuck you Madafaka";
        }
    }
}
