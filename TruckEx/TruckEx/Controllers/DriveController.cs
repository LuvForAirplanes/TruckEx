using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TruckEx.Controllers
{
    [Produces("application/json")]
    [Route("api/Drive")]
    public class DriveController : Controller
    {
        // GET: api/Drive
        [HttpGet]
        public object Get()
        {
            return GetValues();
        }

        // GET: api/Drive/command
        [HttpGet("{command}", Name = "Get")]
        public object Get(string command)
        {
            switch (command.ToLower())
            {
                case "start":
                    GPIO.SetValue(GPIO.Relay.Drive, "1");
                    break;
                case "stop":
                    GPIO.SetValue(GPIO.Relay.Drive, "0");
                    break;
                case "forward":
                    GPIO.SetValue(GPIO.Relay.Direction, "0");
                    break;
                case "backward":
                    GPIO.SetValue(GPIO.Relay.Direction, "1");
                    break;
                case "right":
                    GPIO.SetValue(GPIO.Relay.Steering, "0");
                    GPIO.SetValue(GPIO.Relay.SteeringDirection, "0");
                    break;
                case "left":
                    GPIO.SetValue(GPIO.Relay.Steering, "0");
                    GPIO.SetValue(GPIO.Relay.SteeringDirection, "1");
                    break;
                default:
                    break;
            }
            return GetValues();
        }

        private static object GetValues()
        {
            return new
            {
                drive = GPIO.GetValue(GPIO.Relay.Drive),
                direction = GPIO.GetValue(GPIO.Relay.Direction),
                steering = GPIO.GetValue(GPIO.Relay.Steering),
                steeringDirection = GPIO.GetValue(GPIO.Relay.SteeringDirection)
            };
        }
    }
}
