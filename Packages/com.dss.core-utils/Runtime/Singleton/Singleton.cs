using UnityEngine;
 
namespace DSS.CoreUtils
{

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance = null;

    public static T Instance
    {
        get
        {
            m_instance = Object.FindObjectOfType<T>(true);
            return m_instance;
        }
    }
}

}  // namepace DSS.CoreUtils