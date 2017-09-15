using UnityEngine;
using System.Collections;

public abstract class MonoSingletion<T> : MonoBehaviour where T : MonoBehaviour {

    private static string rootName = "MonoSingletionRoot";
    private static GameObject monoSingletionRoot;

    private static T instance;
    public static T Instance
    {
        get
        {
            if (monoSingletionRoot == null)
            {
                monoSingletionRoot = GameObject.Find(rootName);
                if (monoSingletionRoot == null)
                {
                    monoSingletionRoot = new GameObject("MonoSingletionRoot");
                    monoSingletionRoot.AddComponent<T>();
                }
            }
            if (instance == null)
            {
                instance = monoSingletionRoot.GetComponent<T>();
                if (instance == null) instance = monoSingletionRoot.AddComponent<T>();
            }
            return instance;
        }
    }

}