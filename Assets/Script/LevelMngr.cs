using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMngr : Singleton<LevelMngr>
{
    public int lvlIndex;

    // Start is called before the first frame update
    void Start()
    {
        loadScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void loadScene()
    {
        SceneManager.LoadScene(lvlIndex, LoadSceneMode.Additive);
    }
}
