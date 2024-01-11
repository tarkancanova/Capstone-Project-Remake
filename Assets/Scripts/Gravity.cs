using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Gravity : MonoBehaviour
{
    [Inject]
    PlayerAction _playerAction;
    private float _gravityConstant = 9.81f;
    public void ApplyGravity()
    {
        if (!_playerAction.groundController.isGrounded)
        {
            float gravityScale = _playerAction.moveVector.y < 0 ? 2.0f : 1.0f;
            _playerAction.moveVector.y -= _gravityConstant * gravityScale * Time.deltaTime;
        }
        else if (!_playerAction.isJumpPressed)
        {
            _playerAction.moveVector.y = -0.1f;
        }

        _playerAction.characterController.Move(new Vector3(0, _playerAction.moveVector.y, 0) * Time.deltaTime);
        
    }
}
