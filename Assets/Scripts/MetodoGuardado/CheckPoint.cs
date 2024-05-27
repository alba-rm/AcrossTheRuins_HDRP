using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private string checkpointID;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Save.instance.SaveData(checkpointID);
        }
    }
}