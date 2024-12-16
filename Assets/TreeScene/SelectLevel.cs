using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    DontDestroy dontDestroy;

    [SerializeField] string goToScene;
    [SerializeField] int gameNr;


    public int GameNr { get { return gameNr; } }

    private void Start()
    {
        dontDestroy = GameObject.Find("DontDestroy").GetComponent<DontDestroy>();
        if (dontDestroy.gameStates[gameNr])
        {
            //present is opened
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        Scene oldScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(goToScene);
        SceneManager.UnloadSceneAsync(oldScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
