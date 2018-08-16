using UnityEngine;

public class PlatformController : MonoBehaviour
{
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
    float platformXSize = GetComponent<MeshRenderer>().bounds.size.x;

    leftBorderX = leftBorder.transform.position.x;
    rightBorderX = GameObject.Find("RightBorder").transform.position.x;

    leftBorderX += platformXSize / 2 + borderSize / 2;
    rightBorderX -= platformXSize / 2 + borderSize / 2;
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
    MovePlatformWithMouse();
  }

  private void MovePlatformWithMouse()
  {
    Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    float positionDelta = curPosition.x - lastMousePosition.x;
    transform.position = new Vector3(Mathf.Clamp(transform.position.x + positionDelta, leftBorderX, rightBorderX), transform.position.y, 0f);
    lastMousePosition = curPosition;
  }
}
