using System;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
  public Text CounterText;

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name.Equals("ball", StringComparison.InvariantCultureIgnoreCase))
    {
      CounterText.text = (int.Parse(CounterText.text) + 1).ToString();
    }
  }
}
