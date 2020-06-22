public class DDOL : UnityEngine.MonoBehaviour
{

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
