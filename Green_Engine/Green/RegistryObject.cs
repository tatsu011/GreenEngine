using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Engine.Green
{
    public abstract class RegistryObject
    {
        public virtual void PreInit() { } //pre-window init
        public virtual void Init() { } //CPU Init
        public virtual void Update() { }
        public virtual void Draw() { }
        public virtual void LateUpdate() { }

        public virtual void Shutdown() { }
    }
}