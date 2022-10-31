using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    //this things position should be the same as the player
    void LateUpdate()
    {
        transform.position = _player.transform.position + new Vector3(0, 0, -1);
    }
}
