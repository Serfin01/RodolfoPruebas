using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorCustom : MonoBehaviour
{
    public static CursorCustom instance;

    [SerializeField] GameObject cursor;
    //[SerializeField] Texture2D gameCursor;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Sergi")
        {
            Game();
        }
        else
        {
            Menu();
        }
    }
    void Update()
    {
        Cursor.visible = false;
        Vector2 mousePos = Input.mousePosition;
        cursor.transform.position = mousePos;
    }

    void Menu()
    {
        //Cursor.SetCursor(menuCursor, Vector2.zero, CursorMode.Auto);
        
    }

    void Game()
    {
        //Cursor.SetCursor(gameCursor, Vector2.zero, CursorMode.Auto);
        
    }
}
