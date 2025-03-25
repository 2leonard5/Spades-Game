using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public OptionsMenu optionsMenu;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.gameObject.SetActive(false);
        }
    }
}
