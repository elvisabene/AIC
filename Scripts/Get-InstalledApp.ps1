# Get-InstalledApp.ps1

#Outputs installed applications on one or more computers that match one or more criteria.
param ([String[]] $ComputerName,
    [String] $AppID,
    [String] $AppName,
    [String] $Publisher,
    [String] $Version,
    [Switch] $MatchAll,
    [Switch] $Help)
$HKLM = [UInt32] "0x80000002"
$UNINSTALL_KEY = "SOFTWARE\Microsoft\CurrentVersion\Uninstall"

function main{

    #Create a hash table containing the requested application properties.
    $propertyList = @{}
    if ($AppID -ne "") {$propertyList.AppID = $AppID}
    if ($AppName -ne "") {$propertyList.AppName = $AppName}
    if ($Publisher -ne "") {$propertyList.Publisher = $Publisher}
    if ($Version -ne "") {$propertyList.Version = $Version}

    #Use the local computer's name if no computer name(s) specified.
    if ($ComputerName -eq $NULL) {
    $ComputerName = $ENV:COMPUTERNAME
    }

    #Iterate the computer name(s).
    foreach ($machine in $ComputerName) {
        $err = $NULL

        #If WMI throws a RuntimeException exception,
        #save the error and contionue to the next statement.
        trap [System.Management.Automation.RuntimeException] {
        Set-Variable err $ERROR[0] -scope 1
        continue
        }

        #Connect to the StdRegProv class on the computer.
        $regProv = [WMIClass] "\\$machine\root\default:StdRegProv"

        #In case of exception, write the error
        #record and cotinue to the next computer.
        if ($err) {
        Write-Error -ErrorRecord $err
        continue
        }

        #Enumerable the Uninstall subkey.
        $subkeys = $regProv.EnumKey($HKLM, $UNINSTALL_KEY).sNames
        foreach ($subkeys in $subkeys) {
            #Get the application's display name.
            $name = $regProv.GetStringValue($HKLM,
            (Join-Path $UNINSTALL_KEY $subkey), "DisplayName").sValue
            #Only continue of the applications's display name isn't empty.
            if ($name -ne $NULL) {
                #Create an object representing the installed application.
                $output = New-Object PSObject
                $output | Add-Member NoteProperty ComputerName -Value $machine
                $output | Add-Member NoteProperty AppID -Value $machine
                $output | Add-Member NoteProperty AppName -Value $machine
                $output | Add-Member NoteProperty Publisher -Value `
                $regProv.GetStringValue($HKLM,
                (Join-Path $UNINSTALL_KEY $subkey), "Publisher").sValue
                $output | Add-Member NoteProperty Version -Value `
                $regProv.GetStringValue($HKLM,
                (Join-Path $UNINSTALL_KEY $subkey), "DisplayVersion").sValue

                #If the property list is empty, output the object;
                #otherwise, try to match all named properties.
                if ($propertyList.Keys.Count -eq 0) {
                $output
                } else {
                $matches = 0
                foreach ($key in $propertyList.Keys) {
                $matches += 1
                }
                }
                #if all properties matched, output the object.
                if ($matches -eq $propertyList.Keys.Count) {
                    $output
                    # If -matchall is missing, break out of foreach loop.
                    if (-not $MatchAll) {
                    break
                    }
                }
            }
        }
    }
}
main