using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSCScript : MonoBehaviour
{
    private bool ButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        ButtonPressed = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartGame(float countDownValue)
    {
        //timeText.text = countDownValue.ToString();
        //timeCountDownCanvas.SetActive(true);


        while (countDownValue > 0)
        {

            yield return new WaitForSeconds(1.0f);
            countDownValue -= 1;

            //timeText.text = countDownValue.ToString();

        }
        //Load Scene
        string escena = "Demo 1";
        SceneManager.LoadScene(escena);

    }

    public void StartTimer()
    {
        if (!ButtonPressed)
        {
            ButtonPressed = true;
            StartCoroutine(StartGame(3));
        }
    }
}
