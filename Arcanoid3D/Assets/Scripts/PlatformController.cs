using UnityEngine;

public class PlatformController : MonoBehaviour
{

  public float platformSpeed = 1f;
  private Vector3 lastMousePosition;
  private bool gameIsActive;
  private float leftBorderX;
  private float rightBorderX;
  private Vector3 initialPosition;

  void Start()
  {
    initialPosition = transform.position;
    GameObject leftBorder = GameObject.Find("LeftBorder");
    float borderSize = leftBorder.GetComponent<MeshRenderer>().bounds.size.x;
    leftBorderX = leftBorder.transform.position.x;
    rightBorderX = GameObject.Find("RightBorder").transform.position.x;
    float platformXSize = GetComponent<MeshRenderer>().bounds.size.x;
    leftBorderX += (platformXSize / 2 + borderSize / 2);
    rightBorderX -= (platformXSize / 2 + borderSize / 2);
  }

  void OnMouseDown()
  {
    gameIsActive = true;
    lastMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
  }

  void OnMouseUp()
  {
    gameIsActive = false;
    transform.position = initialPosition;
  }

  void Update()
  {
    if (!gameIsActive)
    {
      return;
    }

    Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    transform.position = new Vector3(Mathf.Clamp(transform.position.x + curPosition.x - lastMousePosition.x, leftBorderX, rightBorderX),
      transform.position.y, 0f);
    lastMousePosition = curPosition;
  }
}
