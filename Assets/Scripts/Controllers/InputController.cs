using System.Collections;
using UnityEngine;

namespace ProjectPlatformer
{
    internal sealed class InputController : IExecute
    {
        private readonly PlayerView _player;

        public InputController(PlayerView player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.Rigidbody2D.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f));
        }
    }
}