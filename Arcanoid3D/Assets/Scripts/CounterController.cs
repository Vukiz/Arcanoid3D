using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{

  public Text CounterText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name.Equals("ball", StringComparison.InvariantCultureIgnoreCase))
    {
      CounterText.text = (int.Parse(CounterText.text) + 1).ToString();
    }
  }
}
