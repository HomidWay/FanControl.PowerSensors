using FanControl.Plugins;
using LibreHardwareMonitor.Hardware;

namespace FanControl.PowerSensor
{
    public class PowerSensorPlugin : IPlugin2
    {
        private Computer _computer;
        private readonly List<PluginPowerSensor> _sensors = [];

        public string Name => "Power Sensors";

        public void Initialize() 
        {
            _computer = new Computer
            {
                IsGpuEnabled = true,
                IsCpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsControllerEnabled = true,
                IsBatteryEnabled = true,
                IsPsuEnabled = true,
                IsStorageEnabled = true,
            };

            if (_computer == null)
                throw new Exception("Failed to initialize OpenHardwareMonitor");

            _computer.Open();

            foreach (var hardware in _computer.Hardware)
            {
                foreach (var sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Power)
                    {
                        _sensors.Add(new PluginPowerSensor(sensor));
                    }
                }
            }
        }

        public void Close()
        {
            _computer.Close();
            _sensors.Clear();
        }

        public void Load(IPluginSensorsContainer container)
        {
            foreach (var sensor in _sensors)
            {
                container.TempSensors.Add(sensor);
            }
        }

        public void Update()
        {
            foreach (var hardware in _computer.Hardware)
            {
                hardware.Update();
            }

        }
    }

    public class PluginPowerSensor : IPluginSensor
    {
        private readonly ISensor _sensor;

        public PluginPowerSensor(ISensor sensor) => _sensor = sensor;

        public string Id
        {
            get { return _sensor.Identifier.ToString(); }
        }

        public string Name
        {
            get { return "[POWER SENSOR] " + _sensor.Name; }
        }

        public float? Value
        {
            get { return _sensor.Value / 10; }
        }

        public void Update() { }
    }
}