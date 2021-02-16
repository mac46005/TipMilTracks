using System;
using System.Collections.Generic;
using System.Text;

namespace TipMilTracks
{
    public abstract class Bootstrapper
    {
        public Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }

        private void FinishInitialization()
        {
            throw new NotImplementedException();
        }

        private void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
