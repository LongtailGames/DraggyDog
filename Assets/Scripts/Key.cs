using UnityEngine;

public class Key : Pickup
{
    [SerializeField] private GameObject DoorToDisable;

    protected override bool OnCollect(Collider2D other)
    {
        var result = false;

        if (other.TryGetComponent(out PlayerController wallet))
        {
            DoorToDisable.SetActive(false);
            result = true;
        }

        return result;
    }
}