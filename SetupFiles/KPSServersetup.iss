; �ű��� Inno Setup �ű��� ���ɣ�
; �йش��� Inno Setup �ű��ļ�����ϸ��������İ����ĵ���
;"��ҵ��ר��ϵͳ"

#define MyAppName "{cm:MyAppName}"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "{cm:MyAppPublisher}"
#define MyAppURL "http://www.ISCAS.com"
#define MyAppExeName "KPS.exe"

[Setup]
; ע: AppId��ֵΪ������ʶ��Ӧ�ó���
; ��ҪΪ������װ����ʹ����ͬ��AppIdֵ��
; (�����µ�GUID����� ����|��IDE������GUID��)
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
OutputBaseFilename=ҽ����е���������ϵͳ_��������
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
chinesesimp.MyAppName=ҽ����е���������ϵͳ_��������
chinesetrad.MyAppName=ҽ����е���������ϵͳ_��������
chinesesimp.MyAppPublisher=markeluo
chinesetrad.MyAppPublisher=markeluo
chinesesimp.DefaultGroupName=ҽ����е���������ϵͳ
chinesetrad.DefaultGroupName=ҽ����е���������ϵͳ

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "netframework\dotnetfx.exe"; DestDir: "{tmp}"; Flags: ignoreversion
Source: "VisualBasicPowerPacks\VisualBasicPowerPacksSetup.exe"; DestDir: "{tmp}"; Flags: ignoreversion
Source: "AccessDatabaseEngine\AccessDatabaseEngine.exe"; DestDir: "{tmp}"; Flags: ignoreversion
Source: "KPS\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; ע��: ��Ҫ���κι���ϵͳ�ļ���ʹ�á�Flags: ignoreversion��

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














