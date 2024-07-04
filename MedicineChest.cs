using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    [SerializeField] private int _addingHealth;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.Heal(_addingHealth);
            Destroy(gameObject);
        }
    }
}
