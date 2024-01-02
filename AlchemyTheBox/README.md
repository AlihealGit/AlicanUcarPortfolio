# The Box
# Photos
<p align="left">
Schematic:
  
<img src="https://github.com/AlihealGit/AlicanUcarPortfolio/blob/main/AlchemyTheBox/Schematic.png">


</p>

Board:
<p align="left">  

<img src="https://github.com/AlihealGit/AlicanUcarPortfolio/blob/main/AlchemyTheBox/Board.png" alt="rocketcard2" border="0" width = 450>
<img src="https://github.com/AlihealGit/AlicanUcarPortfolio/blob/main/AlchemyTheBox/alchemythebox.jpg" alt="rocketcard3" border="0" width = 450 height= 450>

</p>

The Board includes SSR Relay Trigger Mechanism, Microphone Module, 74HC595 Buffer IC for Leds, Buzzer, 555 Timer and J-K Flip Flop for Delay Button Circuit (hold 3 seconds to activate and deactive to power connection), and BNO055 9-DOF Orientation IMU.

# Rocket
<a href="https://ibb.co/R7ZcR9y"><img src="https://i.ibb.co/0Q8rHct/rocketitself.jpg" alt="rocketitself" border="0"></a>

Mission of the card is balancing the rocket while landing with an active control system that controls the selenoid valves. I also created the control algorithm of the rocket. The mission of the card is helded succesfully, the rocket kept its balance at euler angles. However, as the vertical thrust isn't enough to slow down the rocket, it crashed into ground fast, then it bounced off the ground and fell. Here is the releasing video of the rocket:

<img src="https://github.com/AlihealGit/AlicanUcarPortfolio/blob/main/rocketvideo.gif">

# Ground Station

The ground statin is created with the .NET Framework 4.7.2. I learned to use OpenGL and angular transition matrixes to create an animated rocket to show angles that received from the Flight Control Card. Also, the rocket model in the Ground Station original model of the our rocket.

<img src="https://github.com/AlihealGit/AlicanUcarPortfolio/blob/main/GST.gif">
