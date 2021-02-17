using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelTrigger : MonoBehaviour
{
    public string tag;
    public LevelChanger levelChanger;
    public string levelToFadeTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == tag)
        {
            levelChanger.FadeToLevel(levelToFadeTo);
        }
    }
}
