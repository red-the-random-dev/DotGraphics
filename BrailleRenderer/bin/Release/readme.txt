DotGraphics Braille Renderer

/!\ Do not separate DLL library from executable file, as it contains needed classes.

This application is used for rendering monochome transparent images into Braille ASCII art.

How-to: A 4-step tutorial of making your art:
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

(C) 2021 redthedev
Distributed under GPL license.