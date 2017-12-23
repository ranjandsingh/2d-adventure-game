using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class popupText : MonoBehaviour {

    public Text text1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void PopupUpdate(bool safe, bool points, bool coinDouble)
    {
        if(safe)
        {
        text1.text = "Safe Mode!";
        }
        if (points)
        {
            text1.text = "Double Points!";
        }
        if (coinDouble)
            text1.text = "Double Coins!";
        gameObject.SetActive(true);
        StartCoroutine(Fade());
    }
    


    IEnumerator Fade()
    {
        
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
