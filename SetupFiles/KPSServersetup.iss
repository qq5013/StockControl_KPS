; 脚本由 Inno Setup 脚本向导 生成！
; 有关创建 Inno Setup 脚本文件的详细资料请查阅帮助文档！
;"产业化专利系统"

#define MyAppName "{cm:MyAppName}"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "{cm:MyAppPublisher}"
#define MyAppURL "http://www.ISCAS.com"
#define MyAppExeName "KPS.exe"

[Setup]
; 注: AppId的值为单独标识该应用程序。
; 不要为其他安装程序使用相同的AppId值。
; (生成新的GUID，点击 工具|在IDE中生成GUID。)
AppId={{2E8C590C-70E7-40C3-A10D-9B00A2B05471}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\KPS
DefaultGroupName={cm:DefaultGroupName}
DisableProgramGroupPage=yes
OutputDir=Output\KPS
OutputBaseFilename=医疗器械进销存管理系统_服务器端
Compression=lzma
SolidCompression=yes
WizardImageFile=WizModernImage.bmp
;WizardSmallImageFile=IPSLogo1.bmp
;ShowLanguageDialog=no
ArchitecturesInstallIn64BitMode=x64

[Languages]
Name: "chinesesimp"; MessagesFile: "compiler:Languages\ChineseSimp.isl"
Name: "chinesetrad"; MessagesFile: "compiler:Languages\ChineseTrad.isl"

[CustomMessages]
chinesesimp.MyAppName=医疗器械进销存管理系统_服务器端
chinesetrad.MyAppName=医疗器械进销存管理系统_服务器端
chinesesimp.MyAppPublisher=markeluo
chinesetrad.MyAppPublisher=markeluo
chinesesimp.DefaultGroupName=医疗器械进销存管理系统
chinesetrad.DefaultGroupName=医疗器械进销存管理系统

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "netframework\dotnetfx.exe"; DestDir: "{tmp}"; Flags: ignoreversion
Source: "VisualBasicPowerPacks\VisualBasicPowerPacksSetup.exe"; DestDir: "{tmp}"; Flags: ignoreversion
Source: "AccessDatabaseEngine\AccessDatabaseEngine.exe"; DestDir: "{tmp}"; Flags: ignoreversion
Source: "KPS\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”

[Dirs]
Name:"{app}\";Permissions:everyone-modify

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}";WorkingDir: "{app}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}";WorkingDir: "{app}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}";WorkingDir: "{app}"; Tasks: quicklaunchicon
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"

[code]
function CheckDotNet4_0():Boolean;
begin
  Result:=not RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\policy\v4.0');
end;

function CheckACEEngine():Boolean;
begin
  Result:=not RegKeyExists(HKLM,'SOFTWARE\Microsoft\Classes\.accdb');
end;

function CheckVBPowerPacks():Boolean;
begin
  Result:=true;
end;

function InitializeSetup():Boolean;
  var Path:string;
  ResultCode:Integer;
 begin
  if CheckDotNet4_0() then
  begin
    ExtractTemporaryFile('dotnetfx.exe');
    Exec(ExpandConstant('{tmp}\dotnetfx.exe'),'','',SW_SHOWNORMAL,ewWaitUntilTerminated,ResultCode);
  end;
  if CheckVBPowerPacks() then
  begin
    ExtractTemporaryFile('VisualBasicPowerPacksSetup.exe');
    Exec(ExpandConstant('{tmp}\VisualBasicPowerPacksSetup.exe'),'','',SW_SHOWNORMAL,ewWaitUntilTerminated,ResultCode);
  end;
 if CheckACEEngine() then
  begin
    ExtractTemporaryFile('AccessDatabaseEngine.exe');
    Exec(ExpandConstant('{tmp}\AccessDatabaseEngine.exe'),'','',SW_SHOWNORMAL,ewWaitUntilTerminated,ResultCode);
  end;
  Result:= true;
end;














