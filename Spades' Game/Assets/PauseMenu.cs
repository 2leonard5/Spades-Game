using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public PauseMenu pauseMenu;

    void Start(){

    }

    public void Home(){
        SceneManager.LoadScene(0);
    } 

    public void Settings(){
        
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.gameObject.SetActive(!(pauseMenu.gameObject.activeSelf));
        }
    }
}
