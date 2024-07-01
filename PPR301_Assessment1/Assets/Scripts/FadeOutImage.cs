using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOutImage : MonoBehaviour
{
    public Image imageToFade; // The Image component you want to fade out
    public float fadeDuration = 2f; // Duration of the fade out

    private void Start()
    {
        if (imageToFade != null)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            Debug.LogWarning("ImageToFade is not assigned.");
        }
    }

    private IEnumerator FadeOut()
    {
        float startAlpha = imageToFade.color.a; // Initial alpha of the image
        float rate = 1.0f / fadeDuration; // Calculate the rate of change

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * rate)
        {
            Color newColor = imageToFade.color;
            newColor.a = Mathf.Lerp(startAlpha, 0, t); // Interpolate alpha value
            imageToFade.color = newColor; // Apply the new color
            yield return null; // Wait until the next frame
        }

        Color finalColor = imageToFade.color;
        finalColor.a = 0;
        imageToFade.color = finalColor; // Ensure the image is fully transparent at the end
    }
}
