using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Supernova
{
    class ManagerInput
    {
        private ManagerNetwork managerNetwork;

        public ManagerInput(ManagerNetwork m)
        {
            managerNetwork = m;
        }

        public void Update(double gameTime)
        {
            var state = Keyboard.GetState();
            CheckKeyState(Keys.Down, state);
            CheckKeyState(Keys.Up, state);
            CheckKeyState(Keys.Left, state);
            CheckKeyState(Keys.Right, state);
        }

        private void CheckKeyState(Keys key, KeyboardState state)
        {
            if(state.IsKeyDown(key))
            {
                managerNetwork.SendInput(key);
            }
        }
    }
}
