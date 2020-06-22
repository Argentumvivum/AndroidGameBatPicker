using UnityEngine;

public class Options : MonoBehaviour {

    public bool sfx;

    public void SaveOptions()
    {
        PlayerPrefs.SetInt("SFX", sfx ? 1 : 0);
    }

    public void LoadOptions()
    {
        sfx = PlayerPrefs.GetInt("SFX", 0) == 1 ? true : false;
    }
}
