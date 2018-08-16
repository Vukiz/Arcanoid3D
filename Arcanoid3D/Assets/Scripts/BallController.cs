using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{

  public float BallInitialVelocity = 600f;

  public float InitialRotationSpeed = 10f;

  public float SpeedOnHitMultiplier = 1.1f;

  public float PlatformRotationChange = 30f;

  public float BallSpeedLimit = 20f;

  private Rigidbody rb;
  private bool ballInPlay;
  private Vector3 initialPosition;

  void Awake()
  {

    rb = GetComponent<Rigidbody>();
    initialPosition = transform.position;

  }

  void Update()
  {
    if (Input.GetKeyUp(KeyCode.Mouse0))//reset ball position
      {
        ballInPlay = false;
        transform.position = initialPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = Quaternion.identity;
      }
    if (!ballInPlay)
    {
      if (Input.GetKeyDown(KeyCode.Mouse0))
      {
        ballInPlay = true;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Random.Range(20, 160));
        rb.AddForce(new Vector3(transform.right.x, transform.right.y, 0)* BallInitialVelocity);
      }
    }
    else
    {
      transform.Rotate(transform.forward, InitialRotationSpeed * Time.deltaTime);
    }
  }

  void OnCollisionExit(Collision col)
  {
    if (col.gameObject.name.Equals("Platform", StringComparison.InvariantCultureIgnoreCase))
    {
      Debug.Log("Last rotaton " + transform.rotation);
    }
  }

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.name.Equals("Platform", StringComparison.InvariantCultureIgnoreCase))
    {
      if (transform.position.y >= col.transform.position.y && rb.velocity.magnitude < BallSpeedLimit)//increase ball speed
      {
        rb.velocity *= SpeedOnHitMultiplier;
      }

      float platformHalfSize = col.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2;
      ContactPoint contactPoint = col.contacts[0];
      float distanceFromCenter = contactPoint.point.x - col.gameObject.transform.position.x; //negative to the left; positive to the right;
      float normalizedDistance = distanceFromCenter / platformHalfSize;
      rb.velocity = Quaternion.Euler(0,0,PlatformRotationChange * normalizedDistance) * rb.velocity;
      Debug.Log(transform.eulerAngles.z + " " + transform.eulerAngles.z + PlatformRotationChange * normalizedDistance);
    }
  }
}