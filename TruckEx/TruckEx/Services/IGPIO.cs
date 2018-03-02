using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckEx.Services
{
    public enum Relay
    {
        Forward,
        Reverse,
        Left,
        Right,
        FrontLights,
        BackLights
    }

    public enum Value
    {
        On,
        Off
    }

    public interface IGPIO
    {
        void SetValue(Relay relay, Value value);

        string GetValue(Relay relay);
    }
}
