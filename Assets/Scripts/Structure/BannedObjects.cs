using UnityEngine;

public class BannedObjects : MonoBehaviour
{
    [SerializeField]
    private PickableBundle _bannedBundle;

    public int Quantity => _bannedBundle.Quantity;

    public void Ban(PickableObject objectToBan)
    {
        _bannedBundle.AddObject(objectToBan);
        PlayerPrefs.SetInt("bannedAmount", Quantity);
    }

    public void ClearData()
    {
        _bannedBundle.Clear();
    }
}
