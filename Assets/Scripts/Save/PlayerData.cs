using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float playerPositionX;
    public float playerPositionY;
    public float playerPositionZ;
    public int currentScene;
    public int checkpointID;

    public PlayerData(Vector3 position, int scene, int checkpoint)
    {
        playerPositionX = position.x;
        playerPositionY = position.y;
        playerPositionZ = position.z;
        currentScene = scene;
        checkpointID = checkpoint;
    }
}
