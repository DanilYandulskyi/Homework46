using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
        
    public void Move(Vector2 direction)
    {
        Vector2 offset = direction.normalized * (_speed * Time.deltaTime);

        transform.Translate(offset);
    }

    public Vector2 DeployVector(Vector2 direction)
    {
        return -direction;
    }
}