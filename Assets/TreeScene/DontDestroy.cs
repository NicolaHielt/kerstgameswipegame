using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
   
    public List<bool> gameStates = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void LoadScene(string sceneName, int gameNr)
    {
        LoadScene(sceneName);
        gameStates[gameNr] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
