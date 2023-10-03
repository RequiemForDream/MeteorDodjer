using System.Collections;
using UnityEngine;

namespace Utils
{
    public class CoroutineExtension : MonoBehaviour
    {
        private static CoroutineExtension _instance
        {
            get
            {
                if (m_instance == null)
                {
                    var go = new GameObject("[COROUTINE MANAGER]");
                    m_instance = go.AddComponent<CoroutineExtension>();
                    DontDestroyOnLoad(go);
                }

                return m_instance;
            }
        }

        private static CoroutineExtension m_instance;

        public static Coroutine StartRoutine(IEnumerator enumerator)
        {
            return _instance.StartCoroutine(enumerator);
        }

        public static void StopRoutine(Coroutine coroutine)
        {
            if (coroutine != null)
            {
                _instance.StopCoroutine(coroutine);
            }
        }
    }
}
