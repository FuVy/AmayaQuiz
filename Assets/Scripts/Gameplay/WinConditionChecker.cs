using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinConditionChecker : MonoBehaviour
{
    [SerializeField]
    public UnityEvent EndGame;

    [SerializeField]
    public UnityEvent AnotherRound;

    public void CheckForGameEndCondition()
    {
        if (PlayerPrefs.GetInt("totalAmount") <= PlayerPrefs.GetInt("bannedAmount"))
        {
            Debug.Log("opa");
            EndGame.Invoke();
        }
        else
        {
            AnotherRound.Invoke();
        }
    }
}
