using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController MenuControllerInstance;
    public bool GameState;
    public GameObject menuElement;   
    void Start()
    {
        GameState=false;
        MenuControllerInstance = this;
    }

    
    void Update()
    {
        
    }

    public void StartTheGame()
    {
        GameState = true;
        menuElement.SetActive(false);
    }

    
}
