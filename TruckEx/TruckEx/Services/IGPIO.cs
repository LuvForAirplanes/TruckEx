using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckEx.Services
{
    public enum Relay
    {
        Drive,
        Direction,
        Steering,
        SteeringDirection,
        FrontLights,
        BackLights
    }

    public interface IGPIO
    {
        void SetValue(Relay relay, string value);

        string GetValue(Relay relay);
    }
}
