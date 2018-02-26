﻿using System;
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
                    truckRelays.SetValue(Relay.FrontLights, Value.On);
                    truckRelays.SetValue(Relay.BackLights, Value.On);
                } else if(status == LightStatus.Off)
                {
                    truckRelays.SetValue(Relay.FrontLights, Value.Off);
                    truckRelays.SetValue(Relay.BackLights, Value.Off);
                }
            }

            if(location == LightLocation.Back)
            {
                if (status == LightStatus.On)
                {
                    truckRelays.SetValue(Relay.BackLights, Value.On);
                }
                else if (status == LightStatus.Off)
                {
                    truckRelays.SetValue(Relay.BackLights, Value.Off);
                }
            }

            if(location == LightLocation.Front)
            {
                if (status == LightStatus.On)
                {
                    truckRelays.SetValue(Relay.FrontLights, Value.On);
                }
                else if (status == LightStatus.Off)
                {
                    truckRelays.SetValue(Relay.FrontLights, Value.Off);
                }
            }
        }

        public void Start(DriveDirection direction)
        {
            state.Drive = direction;
            switch (direction)
            {
                case DriveDirection.Forward:
                    truckRelays.SetValue(Relay.Forward, Value.On);
                    truckRelays.SetValue(Relay.Reverse, Value.Off);
                    break;
                case DriveDirection.Reverse:
                    truckRelays.SetValue(Relay.Forward, Value.Off);
                    truckRelays.SetValue(Relay.Reverse, Value.On);
                    break;
                default:
                    break;
            }
        }

        public void Stop()
        {
            state.Drive = DriveDirection.Stopped;
            truckRelays.SetValue(Relay.Forward, Value.Off);
            truckRelays.SetValue(Relay.Reverse, Value.Off);
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