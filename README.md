# DotGraphics
An open-source PNG to Braille art image converter.

/!\ Do not separate DLL libraries from executable files, as they contain needed classes.

This application is used for rendering monochome transparent images into Braille ASCII art.

How-to: A 4-step tutorial of making your art (Console version):
1) Make transparent PNG image in any available sprite editor. Pixels with Alpha = 0 will represent empty dots, any other color -- filled dots. (Using single-colored image is recommended). Note that image's width must be multiple of 2 and image's height must be multiple of 4.
2) Open Command line (Win+R -> cmd) and link it to execulatble's directory using command 'cd "<full_directory_name_here>"'
3) Run following command: 
br.exe -o "<your_png_file>" "<compiled_braille_screen_save_path>"
4) Run following command:
br.exe -rt "<compiled_braille_screen_file>" "<output_text_file_location>"

After doing this, your monochrome image will be converted to ASCII art.

Usable commands and parameters:

br -s [rest_of_commands]:
__ Disable console output for compilation/render operations. 
br -o <image> <savepath>:
__ Compile braille screen object file using image as reference.
br -rt <object> <savepath>:
__ Render object into text file.
br -example
__ Run example to ensure that application is operating.

Compilation and render commands can be chained:
br -o mypng.png screen.o -rt screen.o myasciiart.txt

For more comfortable interaction, create .bat file with list of commands in executable's directory.

The Windows form version replaces the requirement to type in all commands with graphical interface.
1. Select PNG file using Load from... button in upper section of window
2. Select where to save Braille screen object by use of Save to... button in upper section of window
3. Click "Construct" button, after which message "Compilation complete!" should appear
4. Select constructed object by use of Load from... button in lower section of window
5. Select where to save text file by use of Save to... button in lower section of window
6. Click "Render" button, after which message "Render complete!" should appear

The Editor application is a graphical solution for editing object files manually.

How to do it:
1. Launch BrailleEditor.exe
2. Set up the size of drawing area
3. Use LMB to fill tile and RMB to clear tile.
4. Save the object in needed destination
5. Hit "Render" button to save your art as text

Use 'Undo' button to return to previous step.
Use 'Load from...' button to load saved object. (Clears undo stack)

Compiled objects are usable in all versions of application.

(C) 2021 red-the-random-dev

www.github.com/red-the-random-dev/DotGraphics/

This software and source code are distributed under GNU General Public License v.3.0
