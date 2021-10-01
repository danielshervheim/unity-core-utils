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
            if (m_instance == null)
            {
                m_instance = Object.FindObjectOfType<T>(true);

                if (m_instance == null)
                {
                    throw new MissingReferenceException("You need to have at least one instance of " + typeof(T).ToString() + " in the scene");
                }
            }
            return m_instance;
        }
    }
}

}  // namepace DSS.CoreUtils