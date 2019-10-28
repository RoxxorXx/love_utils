function love.conf(game)
    -- ##### BASICS #####--
    game.console = true
    game.window.vsync = 0
    game.window.title = "Untitled" 
    game.window.icon = nil 

    -- ##### BASIC WINDOW #####--
    game.window.resizable = true
    game.window.width = 800                
    game.window.height = 600                                 
    game.window.minwidth = 1               
    game.window.minheight = 1 
    game.window.borderless = false  
    game.window.fullscreen = false 
    game.window.x = nil                    
    game.window.y = nil

    -- ##### SPECIFIC #####--
    game.identity = nil                    
    game.appendidentity = false            
    game.version = "11.3"                                   
    game.accelerometerjoystick = false      
    game.externalstorage = false           
    game.gammacorrect = false              
 
    -- ##### AUDIO #####--
    game.audio.mic = false                 
    game.audio.mixwithsystem = true        
 
    -- ##### ADVANCED WINDOW #####--
    game.window.fullscreentype = "desktop" 
    game.window.usedpiscale = true                         
    game.window.msaa = 0                   
    game.window.depth = nil                
    game.window.stencil = nil              
    game.window.display = 1                
    game.window.highdpi = false                                
 
    -- ##### MODULES #####--
    game.modules.audio = true              
    game.modules.data = true               
    game.modules.event = true              
    game.modules.font = true               
    game.modules.graphics = true           
    game.modules.image = true              
    game.modules.joystick = true           
    game.modules.keyboard = true           
    game.modules.math = true               
    game.modules.mouse = true              
    game.modules.physics = true            
    game.modules.sound = true              
    game.modules.system = true             
    game.modules.thread = true             
    game.modules.timer = true              
    game.modules.touch = true              
    game.modules.video = true              
    game.modules.window = true             
  end