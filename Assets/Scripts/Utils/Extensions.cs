using UnityEngine.Events;
using UnityEngine.UI;

namespace Utils
{
    public static class Extensions
    {
        public static void Subscribe(Button button, UnityAction unityAction)
        {
            button.onClick.AddListener(unityAction);
        }
    }
}
