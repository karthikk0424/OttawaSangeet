/*===============================================================
Developer:  Karthik Karunakaran
Company:    Vector3Games
================================================================*/

using UnityEngine;

namespace Vector3Games.Core
{ 
    public class Singleton<T> : MonoBehaviour
        where T : Singleton<T>
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var objs = FindObjectsOfType(typeof(T)) as T[];
                    if (objs.Length > 0)
                        _instance = objs[0];
                    if (objs.Length > 1)
                    {
                        Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                    }
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.hideFlags = HideFlags.HideAndDontSave;
                        _instance = obj.AddComponent<T>();
                        DontDestroyOnLoad(obj);
                    }
                }
                return _instance;
            }
        }
    }
}

