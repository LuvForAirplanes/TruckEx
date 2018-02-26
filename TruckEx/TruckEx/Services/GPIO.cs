using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TruckEx.Services
{
    public class GPIO : IGPIO
    {
        const string Drive = "gpio112.txt";
        const string Direction = "gpio113.txt";
        const string Steering = "gpio114.txt";
        const string SteeringDirection = "gpio115.txt";
        const string FrontLights = "gpio116.txt";
        const string BackLights = "gpio117.txt";

        const string Folder = @"C:\DebugTruckEx\";

        public void SetValue(Relay relay, string value)
        {
            switch (relay)
            {
                case Relay.Drive:
                    WriteFile(Drive, value);
                    break;
                case Relay.Direction:
                    WriteFile(Direction, value);
                    break;
                case Relay.Steering:
                    WriteFile(Steering, value);
                    break;
                case Relay.SteeringDirection:
                    WriteFile(SteeringDirection, value);
                    break;
                case Relay.BackLights:
                    WriteFile(BackLights, value);
                    break;
                case Relay.FrontLights:
                    WriteFile(FrontLights, value);
                    break;
                default:
                    break;
            }
        }

        public string GetValue(Relay relay)
        {
            switch (relay)
            {
                case Relay.Drive:
                    return ReadFile(Drive);
                case Relay.Direction:
                    return ReadFile(Direction);
                case Relay.Steering:
                    return ReadFile(Steering);
                case Relay.SteeringDirection:
                    return ReadFile(SteeringDirection);
                default:
                    return string.Empty;
            }
        }

        private string ReadFile(string file)
        {
            string filePath = Path.Combine(Folder, file);
            if (File.Exists(filePath))
                return File.ReadAllText(filePath);
            else
                return string.Empty;
        }

        private void WriteFile(string file, string value)
        {
            File.WriteAllText(Path.Combine(Folder, file), value);
        }
    }
}
