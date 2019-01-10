--- Galaxy Generator and Animator by Louqou ---

    Thank you for your purchase!
    If you have any questions/issues please email me at: mattbutcher93@gmail.com - I'll be happy to help! :)
    Also I'd be really interested to see anything you make with this asset so please send me some screenshots
    or videos to my email or twitter @Louqou1


--- Getting Started ---

    After looking at the example galaxy in the 'GalaxyDusty' scene, I recommend going into the scene
    'GalaxyPoints' if you want to get a better idea on how the particle system is generated.

    Press play. You should be able to see concentric circles made up of individual particles. First, click on 
    the 'GalaxyPoints' GameObject in the scene and navigate to the 'Ellipse Points' component in the inspector. Increase the
    variable 'Ellipse Start X Length' to about 0.7. Now you should see the circles turn into ellipses. Next,
    slowly increase the 'Ellipse Rotate Amount'. At around 6.5 you should start to see a galaxy-like structure
    begin to form. Keep increasing to about 15.8 and you should have a spiral galaxy!

    You can make many different looking formations my just changing the 'Ellipse Start X Length', 'Ellipse Start
    Y Length', 'Ellipse Grow Rate', and 'Ellipse Rotate Amount'.

    The last important variable is 'Rotation Speed'. Increase this to 0.2 and you should see the particles move
    along their ellipses. This doesn't look too impressive with small point particles, but with large blurry 
    particles, like in the GalaxyDusty example, it creates a very dynamic and awesome looking effect.


--- Why this works ---

    The reason these structures form is due to density wave theory. When the ellipses are rotated in relation
    to each other areas where many ellipses overlap create clusters which look like galaxy arms. The ellipses in
    the particle systems represent orbitals of stars as they move around the galactic center. If you're interested,
    this is an great article about the effect: http://beltoforion.de/article.php?a=spiral_galaxy_renderer.


--- Variables ---

    ellipseStartXLength             - Width of the first ellipse
             
    ellipseStartYLength             - Height of the first ellipse
             
    ellipseGrowRate                 - Size factor for each new ellipse
             
    ellipseRotateAmount             - How much each new ellipse is rotated (degrees)
             
    pointsPerEllipseStart           - How many particles in the first ellipse
           
    pointPerEllipseGrowRate         - How many more particles in each new ellipse
             
    numberOfParticles               - How many particles to spawn
           
    rotationSpeed                   - How fast each particle orbits the ellipse
           

--- Making your own galaxy particle system ---

    The particle system is set up to have a particle life time of Infinity and with no emission (as the script handles
    this). Also make sure the Max Particles parameter is bigger than the 'Number Of Particles' in 'Ellipse Points' 
    component.  

    I created the galaxy in the example by layering 3 'Ellipse Points' particle systems and one particle system for the galactic
    center. The main particle system is 'GalaxyDusty' it creates the blueish colour and galaxy arms. It uses big,
    smokey textures that add on top of each other. Next I layered a particle system called 'Shadow'. This still uses 
    the 'EllipsePoints' script but uses different parameters to fill in the gaps with dark shadowy looking dust. It uses 
    the same particle texture but with the Particle->Multiply shader. Next, I added small bright starts to the galaxy 
    on top of the 'GalaxyDusty' particle system. This uses a small bright point particle texture. Lastly a particle
    system is used to create a big bright particle in the center of the effect!

--- Thank you! ---

    Thanks again for your purchase, I hope this readme helps you get started. Again, if you have any questions or issues
    please get in contact!

    You can also find me on twitter for more game dev stuff @Louqou1