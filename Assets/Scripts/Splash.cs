using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public float countupTime;
    public Slider slider;
    public Text persen;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (1 > countupTime)
        {
            // countdownDisplay.text = countupTime.ToString();
            // float progress = Mathf.Clamp01(countupTime / 2f);
            // slider.value = progress;
            // countdownDisplay.text = progress * 100f + "%";
            yield return new WaitForSeconds(0.001f);
            countupTime++;
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            persen.text = progress * 100f + "%";
            yield return null;
        }
    }
}
