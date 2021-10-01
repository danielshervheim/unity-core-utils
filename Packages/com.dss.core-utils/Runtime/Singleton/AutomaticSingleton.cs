using UnityEngine;
 
namespace DSS.CoreUtils
{

public class AutomaticSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance = null;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = Object.FindObjectOfType<T>(true);

                if (m_instance == null)
                {
                    GameObject go = new GameObject(typeof(T).ToString() + " (Singleton)");
                    m_instance = go.AddComponent<T>();
                }
            }

            return m_instance;
        }
    }
}

// Source(s)
// ---------
// https://wiki.unity3d.com/index.php/Singleton

}  // namepace DSS.CoreUtils