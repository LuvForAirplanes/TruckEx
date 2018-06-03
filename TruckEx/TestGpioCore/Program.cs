using Bifrost.Devices.Gpio;
using Bifrost.Devices.Gpio.Abstractions;
using Bifrost.Devices.Gpio.Core;
using System;

namespace TestGpioCore
{
    class Program
    {
        private static IGpioController gpioController;

        static void Main(string[] args)
        {
            gpioController = GpioController.Instance;

            var pin = gpioController.OpenPin(2);

            pin.SetDriveMode(GpioPinDriveMode.Output);
            
            Console.WriteLine("Going on");
            pin.Write(GpioPinValue.High);

            Console.WriteLine("Hello World!");
        }
    }
}
