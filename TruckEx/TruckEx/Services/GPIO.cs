using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TruckEx.Services
{
    public class GPIO : IGPIO
    {
        const string Forward = "gpio30/value";
        const string Reverse = "gpio60/value";
        const string Left = "gpio31/value";
        const string Right = "gpio48/value";
        const string FrontLights = "gpio/value";
        const string BackLights = "gpio/value";

        const string Folder = @"/sys/class/gpio";

        public void SetValue(Relay relay, Value value)
        {
            switch (relay)
            {
                case Relay.Forward:
                    WriteFile(Forward, value);
                    break;
                case Relay.Reverse:
                    WriteFile(Reverse, value);
                    break;
                case Relay.Left:
                    WriteFile(Left, value);
                    break;
                case Relay.Right:
                    WriteFile(Right, value);
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
                case Relay.Forward:
                    return ReadFile(Forward);
                case Relay.Reverse:
                    return ReadFile(Reverse);
                case Relay.Left:
                    return ReadFile(Left);
                case Relay.Right:
                    return ReadFile(Right);
                case Relay.FrontLights:
                    return ReadFile(FrontLights);
                case Relay.BackLights:
                    return ReadFile(BackLights);
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

        private void WriteFile(string file, Value value)
        {
            File.WriteAllText(Path.Combine(Folder, file), value.ToString());
        }
    }
}
