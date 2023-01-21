using UnityEngine;

[System.Serializable]
public class PlayerRecords
{
    [SerializeField] private int _attempsCount = 0;

    public int AttempsCount { get => _attempsCount; set => _attempsCount = value; }
}

