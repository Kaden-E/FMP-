using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingtexts = new List<FloatingText>();


    private void Update(){
        foreach(FloatingText txt in floatingtexts)
            txt.UpdateFloatingText();
    }


    public void show(string msg, int fontSize, Color colour, Vector3 position, Vector3 motion, float duration){
        FloatingText floatingText = GetFloatingText();
        floatingText.txt.text = msg; 
        floatingText.txt.fontSize  = fontSize;
        floatingText.txt.color = colour;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);//transfer world space to screen space
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.show();

    }



    private FloatingText GetFloatingText(){
        FloatingText txt = floatingtexts.Find(t => !t.active);

        if (txt == null){
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingtexts.Add(txt);

        }
        return txt;
    }



}
