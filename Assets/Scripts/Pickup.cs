using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class Pickup : MonoBehaviour
{
    [SerializeField] private UnityEvent onCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (OnCollect(other))
        {
            Destroy(gameObject);
            onCollected?.Invoke();
        }
    }

    /// <summary>
    /// Performs the logic of a pickup
    /// e.g increase points
    /// </summary>
    /// <param name="other"></param>
    /// <returns>True if the pickup was collected</returns>
    protected abstract bool OnCollect(Collider2D other);
}