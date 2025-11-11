using System;
using System.Collections.Generic;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private List<ISwitchable> devices = new List<ISwitchable>();
        private List<IEnergyConsumer> energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            devices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer device)
        {
            energyDevices.Add(device);
        }

        public void TurnAllOn()
        {
            foreach (var d in devices)
            {
                d.TurnOn();
            }
        }

        public void TurnAllOff()
        {
            foreach (var d in devices)
            {
                d.TurnOff();
            }
        }

        public void ShowEnergyReport(int hours)
        {
            Console.WriteLine($"\nЗвіт про споживання енергії за {hours} год:");

            double total = 0;

            foreach (var dev in energyDevices)
            {
                double used = dev.GetEnergyUsage(hours);
                total += used;

                Console.WriteLine($"{dev.DeviceName}: {used:F2} кВт·год (потужність: {dev.PowerConsumption} Вт)");
            }

            Console.WriteLine($"Загальне споживання: {total:F2} кВт·год");
            Console.WriteLine($"Вартість (~4 грн/кВт·год): {(total * 4):F2} грн\n");
        }
    }
}

