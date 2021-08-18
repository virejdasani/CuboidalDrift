## OnNewLevel()
- Go to Player GameObject
- Re-Add time scores TMP objects in the TimeScore script
- Add ThisSceneName in the TimeScore script and in the PlayerExplosion script on Player GameObject
- Change the name of the nextLevelCube
- To get proper lighting, go to window->rendering->lighting. Click new lighting settings and check the auto generate box
- In `LevelsSceneHighScores.cs` and `PlayerCollisionHandler.cs` add the new level in the appropriate areas

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

## Platform Switching
- Change the prefabs->light->main light intensity from 1 to 0.8
- Change the prefabs->CubeButtons->FinishLine->point light from 3 to 0.15
- Go to JoystickPack->Prefabs->FixedJoystick-> Uncheck image from both the fixed joystick and its child, handle. Also uncheck the FixedJoystick script
- Go to build settings -> player settings -> resolution and presentation. Choose full-screen mode = windowed. W/H = 1024/576
- In player settings, change the default logo to desktopLogo or logo for mobile

## Notes
- The `PreviewScene` is to get assets like the app logo, preview banner etc.
- When changing platform, if the scenes look too bright, lower the bloom in the global post-process volume
