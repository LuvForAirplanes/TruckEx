using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckEx.Data;

namespace TruckEx.Services
{
    public enum DriveDirection
    {
        Forward,
        Reverse,
        Stopped
    }

    public enum TurnDirection
    {
        Left,
        Right,
        Straight
    }

    public enum LightLocation
    {
        Front,
        Back,
        All
    }

    public enum LightStatus
    {
        On,
        Off,
        Flashing
    }

    public interface ITruck
    {
        void Start(DriveDirection direction);

        void Stop();

        void Turn(TurnDirection direction);

        void Lights(LightLocation location, LightStatus status);

        TruckState GetState();
    }
}
