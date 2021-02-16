using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    public GameObject textBox;
    public float textSpeed;
    public float nextStringDelay;

    public string[] text;
    string testString;

    public Text textComponent;
    int charsInString;

    float secondcounter = 0;
    int stringWeAreOn = 0;

    int endNumber = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        PrepareNextString(text[stringWeAreOn]);
    }

    // Update is called once per frame
    void Update()
    {   
        if(stringWeAreOn < endNumber)
        {
            textBox.SetActive(true);
            if (textComponent.text.Length < charsInString)
            {
                secondcounter += Time.deltaTime;
                if (secondcounter > textSpeed)
                {
                    secondcounter = 0;
                    textComponent.text = textComponent.text + text[stringWeAreOn][textComponent.text.Length];
                }
            }
            else if (textComponent.text.Length == charsInString)
            {
                secondcounter += Time.deltaTime;
                if (secondcounter > nextStringDelay)
                {
                    if (stringWeAreOn < text.Length - 1)
                    {
                        stringWeAreOn += 1;
                        PrepareNextString(text[stringWeAreOn]);
                    }
                    else
                    {
                        textBox.SetActive(false);
                    }
                }
            }
        }
        else
        {
            textBox.SetActive(false);
        }
     
    }

    void PrepareNextString(string _string)
    {
        charsInString = _string.Length;
        textComponent.text = "";
        secondcounter = textSpeed;
    }

    public void PlayUntil(int number)
    {
        endNumber = number;
    }
}
