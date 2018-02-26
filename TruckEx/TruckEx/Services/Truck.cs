using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckEx.Data;

namespace TruckEx.Services
{
    public class Truck : ITruck
    {
        TruckState state = new TruckState();
        GPIO truckRelays = new GPIO();

        public void Lights(LightLocation location, LightStatus status)
        {
            if(location == LightLocation.All)
            {
                if(status == LightStatus.On)
                {
                    truckRelays.SetValue(Relay.FrontLights, "0"); //zero is on in linux
                    truckRelays.SetValue(Relay.BackLights, "0"); //zero is on in linux
                } else if(status == LightStatus.Off)
                {
                    truckRelays.SetValue(Relay.FrontLights, "1"); //zero is on in linux
                    truckRelays.SetValue(Relay.BackLights, "1"); //zero is on in linux
                }
            }

            if(location == LightLocation.Back)
            {
                if (status == LightStatus.On)
                {
                    truckRelays.SetValue(Relay.BackLights, "0"); //zero is on in linux
                }
                else if (status == LightStatus.Off)
                {
                    truckRelays.SetValue(Relay.BackLights, "1"); //zero is on in linux
                }
            }

            if(location == LightLocation.Front)
            {
                if (status == LightStatus.On)
                {
                    truckRelays.SetValue(Relay.FrontLights, "0"); //zero is on in linux
                }
                else if (status == LightStatus.Off)
                {
                    truckRelays.SetValue(Relay.FrontLights, "1"); //zero is on in linux
                }
            }
        }

        public void Start(DriveDirection direction)
        {
            state.Drive = direction;
        }

        public void Stop()
        {
            state.Drive = DriveDirection.Stopped;
        }

        public void Turn(TurnDirection direction)
        {
            state.Steering = direction;
        }

        public TruckState GetState()
        {
            return state;
        }
    }
}
