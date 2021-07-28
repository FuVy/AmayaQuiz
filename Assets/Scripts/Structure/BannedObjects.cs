using UnityEngine;

public class BannedObjects : MonoBehaviour
{
    [SerializeField]
    private PickableBundle _bannedBundle;

    public void Ban(PickableObject objectToBan)
    {
        _bannedBundle.AddObject(objectToBan);
    }
}
