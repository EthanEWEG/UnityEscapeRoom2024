using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sparks : MonoBehaviour
{
    // Set the minimum and maximum duration for sparks to stay visible
    public float minSparkDuration;
    public float maxSparkDuration;

    // Set the minimum and maximum delay between sparks
    public float minDelay;
    public float maxDelay;

    //Sparks sprite
    public Image sparksLeftImage;
    public Image sparksRightImage;

    //used to stop the annoying spark noises
    public GameObject powerON;

    //reference to audio of sparks that gives the code
    public AudioSource sparksAudioCode;

    void Start()
    {
        if (!powerON.activeSelf)
        {
            sparksAudioCode.Play();
        }
        //Initializes the spark animation coroutine
        StartCoroutine(SparkAnimation());
    }

    private void Update()
    {
        if (powerON.activeSelf)
        {
            sparksAudioCode.Stop();
        }
    }

    private IEnumerator SparkAnimation()
    {
        while (true)
        {
            //Random float between 0 and 1 that decides if left spark animation will play or right spark
            float side = Random.Range(0f, 1f);
            if (side > 0.5f)
            {
                StartCoroutine(SparkFadeOut(sparksLeftImage));
            }
            else
            {
                StartCoroutine(SparkFadeOut(sparksRightImage));
            }

            // Wait for a random delay before showing the next spark
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }
    private IEnumerator SparkFadeOut(Image sparkImage)
    {
        //random fade duration
        float fadeDuration = Random.Range(minSparkDuration, maxSparkDuration);

        //Lowers the alpha value over the fadeDuration time.
        Color fadeColor = sparkImage.color;
        for (float t = 0; t < fadeDuration; t += Time.unscaledDeltaTime)
        {
            fadeColor.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            sparkImage.color = fadeColor;
            yield return null;
        }
    }
}
