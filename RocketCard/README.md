# Flight Control Card and Ground Station for TEKNOFEST Vertical Landing Rocket Competition
# Photos
<p align="left">
<a href="https://ibb.co/nMfGCwV"><img src="https://i.ibb.co/B2jpNf7/rocketcard1.jpg" alt="rocketcard1" border="0" width = 220></a>
<a href="https://ibb.co/NFdY5dK"><img src="https://i.ibb.co/MgxNrx7/rocketcard2.jpg" alt="rocketcard2" border="0" width = 220></a>
<a href="https://ibb.co/D8X11Py"><img src="https://i.ibb.co/vQ5ccCG/rocketcard3.jpg" alt="rocketcard3" border="0" width = 220></a>
<a href="https://ibb.co/8cNg6hz"><img src="https://i.ibb.co/74jt29g/rocket4.jpg" alt="rocket4" border="0" width = 220 height = 391></a>
</p>

The Flight Control Card contains STM32F411CEU6 MCU, BNO055 9-DOF Orientation Sensor, MS5611 barometric pressure sensor, SD Card Logger, and HC-12 RF Communication Module.

# Rocket
<a href="https://ibb.co/R7ZcR9y"><img src="https://i.ibb.co/0Q8rHct/rocketitself.jpg" alt="rocketitself" border="0"></a>

Mission of the card is balancing the rocket while landing with an active control system that controls the selenoid valves. I also created the control algorithm of the rocket. The mission of the card is helded succesfully, the rocket kept its balance at euler angles. However, as the vertical thrust isn't enough to slow down the rocket, it crashed into ground fast, then it bounced off the ground and fell. Here is the releasing video of the rocket:

<img src="https://github.com/AlihealGit/AlicanUcarPortfolio/blob/main/rocketvideo.gif">

# Ground Station

The ground statin is created with the .NET Framework 4.7.2. I learned to use OpenGL and angular transition matrixes to create an animated rocket to show angles that received from the Flight Control Card. Also, the rocket model in the Ground Station original model of the our rocket.

<img src="https://github.com/AlihealGit/AlicanUcarPortfolio/blob/main/GST.gif">
