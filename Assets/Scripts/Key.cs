using UnityEngine;

public class Key : Pickup
{
    [SerializeField] private GameObject doorToDisable;

    protected override bool OnCollect(Collider2D other)
    {
        var result = false;

        if (other.TryGetComponent(out PlayerController wallet))
        {
            doorToDisable.SetActive(false);
            result = true;
        }

        return result;
    }
}