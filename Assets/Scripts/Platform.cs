using UnityEngine;

public class Platform : MonoBehaviour
{
    [Min(0)]
    public float movementSpeed = 6f;

    // ���������� �� ������ ��������� �� �� ����
    private float halfWidth;

    // �������, �� ������� ��������� ������ ������������
    private float moveBorder;

    private void Start()
    {
        moveBorder = CameraBorders.Borders.x;
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        halfWidth = (collider.bounds.max.x - collider.bounds.min.x) / 2;
    }

    public void Move(int direction)
    {
        if (transform.position.x + halfWidth > moveBorder && direction == 1)
        {
            return;
        }
        if (transform.position.x - halfWidth < -moveBorder && direction == -1)
        {
            return;
        }

        transform.position += Vector3.right * direction * movementSpeed * Time.deltaTime;
    }
}
