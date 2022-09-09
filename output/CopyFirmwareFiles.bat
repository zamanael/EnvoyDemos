echo

attrib -R "Firmware"\*.* /S /D
attrib -R "C:\CA4K_CDIMAGE_1.1.50\Firmware"\*.* /S /D

copy "Firmware\*.*" "C:\CA4K_CDIMAGE_1.1.50\Firmware"


echo

attrib -R "Documentation\Readme.* /S /D
attrib -R "C:\CA4K_CDIMAGE_1.1.50\Documentation\Readme.* /S /D
copy "Documentation\Readme.*" "C:\CA4K_CDIMAGE_1.1.50\Installation Documents"

attrib -R "Documentation\*.htm /S /D
attrib -R "C:\CA4K_CDIMAGE_1.1.50\Documentation\*.htm /S /D
copy "Documentation\*.htm" "C:\CA4K_CDIMAGE_1.1.50\Installation Documents"

