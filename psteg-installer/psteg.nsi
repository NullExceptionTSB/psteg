OutFile "psteg-setup.exe"
SetCompressor /SOLID /FINAL lzma
XPStyle on
LicenseText "GNU GPLv3-or-later"

UninstallIcon ..\icon-uninstall.ico
Icon ..\icon-install.ico
!include "MUI2.nsh"

!define MUI_ABORTWARNING
!define MUI_ICON ..\icon-install.ico
!define MUI_UNICON ..\icon-uninstall.ico

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "..\LICENSE"
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

!insertmacro MUI_LANGUAGE "English"

Name "psteg Beta 3"

InstallDir "C:\Program Files\psteg"
	
Section
	SetOutPath $INSTDIR
	
	WriteUninstaller $INSTDIR\uninstall.exe

	File ..\psteg-common\bin\Debug\psteg-common.dll 
	File /oname=chaffblob.exe ..\psteg-chaffblob\bin\Debug\psteg.Chaffblob.exe
	File /oname=stegano.exe ..\psteg-stegano\bin\Debug\psteg.Stegano.exe 
	File /oname=psteg.exe ..\psteg-launcher\bin\Debug\psteg.Launcher.exe 
	File /oname=fstools.exe ..\psteg-fstools\bin\Debug\psteg.FSTools.exe 
SectionEnd

Section "uninstall"
	Delete $INSTDIR\uninstall.exe

	Delete $INSTDIR\chaffblob.exe
	Delete $INSTDIR\stegano.exe
	Delete $INSTDIR\psteg.exe
	Delete $INSTDIR\fstools.exe
	Delete $INSTDIR\psteg-common.dll
	RMDir $INSTDIR
SectionEnd