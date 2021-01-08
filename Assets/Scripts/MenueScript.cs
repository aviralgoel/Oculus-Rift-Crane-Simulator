using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenueScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject menue;
    public Text myText;
    public Text myText2;
    float time = 200f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        Destroy(myText);
        Destroy(myText2);
    }
    public void OnStart()   
    {
        SceneManager.LoadScene(1);
    }
    public void onExite()
    {
        Application.Quit();
    }
    public void instructions()
    {
        
            panel.SetActive(true);
            menue.SetActive(false);
        
    }
    public void goBack()
    {

        panel.SetActive(false);
        menue.SetActive(true);

    }


}
