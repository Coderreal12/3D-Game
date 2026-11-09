
Making a 3d Game

WEEK 1:

This game is a shell of what it will be in the fututre. My plan for this game is to be a fully working 3d puzzle-based shooter. For the last week I spent time on modling the guns, coding everything, adding a pickup/grab system and much more! Next week I plan to add physcis based puzzles, enimes you can shoot, and much more!

This week, I learned a few things such as 
- Modeling(Importing models from blender to unity)
- SphereCasts

For the modeling, I was able to use my limited Blender knowledge to make a makeshift gun:
<img width="660" height="278" alt="image" src="https://github.com/user-attachments/assets/80a17029-27de-438d-9d31-ebc9e0a9133f" />

It works with all the colors intact!

I also learned how to use spherecasts with my player to make a proper isgrounded script. 

SYSTEMS

For the grab system (Dragging Things in the air) I learned about a ScreenToPoint function; it allowed me to easily make a raycast for the working grab and pickup system. 

(*DISCLAIMER*) AI was used to help this one and ONLY part of the code, it was the fact that when it would grab, it would jitter when it reached it/the weapon would constantly overshoot its target and repeat that cycle, After hours of debugging I caved in and 
asked an AI, All it told me to do was to add a slow down modifier. Everything other line of code was done by me and me only.

For the Pickup system (Equiping Items) I had a hold point parent ed the my camera so it would follow it when you pick it up. It can't shoot just yet; however It will next week!
<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/5c2be9a0-f676-4fa0-842f-61ef0676bc13" />

CONTROLS:

W/S: FORWARD BACK.
A/D: LEFT RIGHT.

R: GRAB
T: LET GO

E: EQUIP GUN
F: LET GO

  
