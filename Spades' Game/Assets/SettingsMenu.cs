using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public SettingsMenu settingsMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            settingsMenu.gameObject.SetActive(false);
        }
    }
}
