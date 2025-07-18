# PowerReader

FanControl plugin to read AIDA64 **Temperature** and **Power** sensors

## Features
- Reads power values from AIDA64
- Outputs data in FanControl sensor format

## Main usecases
-  Though FanControl developer doesn't like idea of controling fans using system power, it still prety usefull feature to have and main goal is to control PSU fan after it was replaced.
Since most PSUs don't have externally accessable temperature sensors, only option to reasonably set fan curve for PSU fan is to estimate required fan speed based on power consumption.

-  Another use case is to control case fans based on amount of heat dumped into your system in case you don't want to wait until inert sensors like system temperature sensors on motherboard are actuallty catching up to increased air temperature inside PC case.

## Installation
1. Download latest release
2. Install .zip file (Settings -> Install plugin...) or place FanControl.PowerSensors.dll and FanControl.PowerSensors.pdb into .../FanControl/Plugins/AIDA64 Power/ manually 


## (Optional) FanControl Configuration
Combine multiple power sensors using Mix custom sensor to estiamte total power usage
1. Open "Home" tab
2. Press "+"
3. Press "Mix" button and add desired sensors with "Sum" functions

# NOTE
1. **Power values are presented as Celsius and are divided by 10 as FanControl doesn't support any units other than Celsius/Farenheit, and curves are limited at 200 degrees maximum.**
**For example if a AIDA64 reports <ins>1000 w</ins>, it will be displayed as <ins>100.0 C</ins> in FanControl.**

3. Power sensors are marked with [POWER SENSOR] prefix in the name.

4. If used to control PSU Fan note that with most motherboards you can't know how much power does every component draws as well as total power draw, and you are usually limited to CPU and GPU packages.
To aproximate what measured power draw your system will have under high load i suggest you run OCCT with Power benchmark and check the power readings you get from sensors you can access.
For example my system has only basic sensors for CPU and GPU, so I combined CPU package and GPU Package to get 400 watts total from readings, then in fact draw from power socket was 550.
Don't forget to adjust to this margin according to number of Fans, Drives and other external devices consuming power fron PSU in your PC.
