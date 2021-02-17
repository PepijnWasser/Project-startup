using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckTextDone : MonoBehaviour
{
    public LevelChanger levelChanger;
    public dialogueManager dialogueManager;
    public string levelToLoad;

    private void Update()
    {
        if (dialogueManager.done)
        {
            levelChanger.FadeToLevel(levelToLoad);
        }
    }
}
