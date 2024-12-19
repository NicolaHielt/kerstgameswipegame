using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    DontDestroy dontDestroy;

    AudioSource audio;
    [SerializeField] ParticleSystem particle;

    [SerializeField] string goToScene;
    [SerializeField] int gameNr;


    public int GameNr { get { return gameNr; } }

    private void Start()
    {
        dontDestroy = GameObject.Find("DontDestroy").GetComponent<DontDestroy>();
        audio = gameObject.GetComponent<AudioSource>();
        if (dontDestroy.gameStates[gameNr])
        {
            //present is opened
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine(OnClick());
    }

    IEnumerator OnClick()
    {
        audio.Play();
        yield return new WaitForSeconds(.3f);
        particle.Play();
        yield return new WaitForSeconds(2);
        Scene oldScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(goToScene);
        SceneManager.UnloadSceneAsync(oldScene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
