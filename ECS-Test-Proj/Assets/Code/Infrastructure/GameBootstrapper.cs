using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        void Start()
        {
            _game = new Game();

            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            _game.RunUpdate();
        }

        private void FixedUpdate()
        {
            _game.RunFixedUpdate();
        }
    }
}