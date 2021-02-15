using UnityEngine;
using System;

public class FallingObject : MonoBehaviour
{
    private FallingObjectData data;
    public static event Action<GameObject> OnObjectDestroy;
    private float halfHeight;


    public void Init(FallingObjectData objectData)
    {
        data = objectData;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = data.color;
        transform.localScale = new Vector3(objectData.scale.x, objectData.scale.y, transform.localScale.z);

        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        halfHeight = (collider.bounds.max.y - collider.bounds.min.y) / 2;
    }

    private void Update()
    {
        transform.position += Vector3.down * data.speed * Time.deltaTime;

        if ((transform.position.y + halfHeight  < -CameraBorders.Borders.y))
        {
            OnObjectDestroy?.Invoke(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (data.type)
        {
            case Type.Friendly:
                GameManager.PlayerPickedFriendlyObject();
                break;

            case Type.Enemy:
                GameManager.PlayerPickedEnemyObject();
                break;
        }

        OnObjectDestroy?.Invoke(gameObject);
    }
}
