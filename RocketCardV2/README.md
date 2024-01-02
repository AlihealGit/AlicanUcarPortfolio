# Flight Control Card V2 for TEKNOFEST Vertical Landing Rocket Competition
# Photos
<p align="left">
<img src="https://github.com/AlihealGit/AlicanUcarPortfolio/blob/main/RocketCardV2/Board.png">
<img src="https://github.com/AlihealGit/AlicanUcarPortfolio/blob/main/RocketCardV2/3D.png">

</p>

The Flight Control Card contains STM32F411CEU6 MCU, BNO085 9-DOF Orientation Sensor, BMP390 barometric pressure sensor, SD Card slot, and RA-02 Lora RF Communication Module.

The previous version of the Flight Control Card is prepared in rush. Therefore, I couldn't order the PCB from professional PCB providers. I had to design the card in only one layer and produce it on the CNC machine. It had a quite challenging design and production process. Also, in the previous version, I used relays which has slow reaction time to trigger selenoid valves. Now, the competation will be held in August 2024 and I started to design the card 31/12/2024. The new card is designed according to rules at AN4488, AN2606 Application notes, STMF411 Datasheet, and AN2867 oscillator design guide. The new card includes latest version of the sensors and I tried to choose the sensors that are most efficient ones among to their price scales. Moreover, Flight Control Card V2 will have a second floor, this floor will contain mosfets as trigger mechanism. In the second floor, the logic side and the high voltage trigger site will be isolated by the optocouplers.
