using System.Collections;
using UnityEngine;

public class BorderLightUp : MonoBehaviour
{
  private Renderer borderRenderer;

  private void Start()
  {
    borderRenderer = GetComponent<Renderer>();
  }

  private void OnCollisionEnter(Collision col)
  {
    StartCoroutine(FadeColor(Color.red, Color.white));
  }

  private IEnumerator FadeColor(Color fromColor, Color toColor)
  {
    float duration = 0.5f;
    float currentTime = 0f;
    borderRenderer.material.color = fromColor;
    while (currentTime < duration)
    {
      borderRenderer.material.color = Color.Lerp(fromColor, toColor, currentTime / duration);
      currentTime += Time.deltaTime;
      yield return null;
    }
  }
}