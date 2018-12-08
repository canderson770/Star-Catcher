using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIBar : MonoBehaviour
{
    Image bar;
    //RectTransform rectT;
    public int amountOfStarsNeeded = 10;

    GameObject rabbit;
    public GameObject secondsText;

    void Start()
    {
        //rectT = GetComponent<RectTransform>();
        bar = GetComponent<Image>();
        rabbit = GameObject.Find("Rabbit");
        //rectT.sizeDelta = new Vector2(0, 6.5f);
    }

    public void UpdateBar()
    {
        //rectT.sizeDelta = new Vector2 (StaticVars.starBarCount * 20, 6.5f);

        bar.fillAmount = (float)StaticVars.starBarCount / (float)amountOfStarsNeeded;

        if (StaticVars.starBarCount >= amountOfStarsNeeded)
        {
            StaticVars.time += StaticVars.secondsToAdd;
            StaticVars.starBarCount = 0;
            //rectT.sizeDelta = new Vector2(0, 6.5f);
            bar.fillAmount = 0;

            Instantiate(secondsText, rabbit.transform.position, Quaternion.identity);
        }
    }
}
