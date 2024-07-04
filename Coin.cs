using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _addingScore;
    [SerializeField] private Score _score;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _score.Increase(_addingScore);
            Destroy(gameObject);
        }
    }
}
