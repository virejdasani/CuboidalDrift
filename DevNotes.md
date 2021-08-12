## OnNewLevel()
- Go to Player GameObject
- Re-Add time scores TMP objects in the TimeScore script
- Add ThisSceneName in the TimeScore script and in the PlayerExplosion script
- Change the name of the nextLevelCube
- To get proper lighting, go to window->rendering->lighting. Click new lighting settings and check the auto generate box

## Piston animation
- Piston comes all the way out at 60 frames
- Piston goes all the way back in at 180 frames
- Takes 1 second to come out and 2 seconds to go back in

## Movement speed
- Touch movement speed = 600
- Keyboard movement speed = 50000

## Level creation
- When placing platform next to each other, make sure they don't overlap
- Make the platform, that is in the direction the player is supposed to go, a little lower than the platform the player is currently in. This will remove the player being stuck
- Make sure to have the player < 1 y on the surface. When it is above 1 y, it can't move 
- Make sure to tag the starting platform 'Surface'. Without this, the timer won't start