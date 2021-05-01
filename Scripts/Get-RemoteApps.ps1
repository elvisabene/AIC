$hive = [Microsoft.Win32.RegistryHive]::LocalMachine
$hostname = [System.Net.Dns]::GetHostName()
$regkey = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\"
$regconnection = [Microsoft.Win32.RegistryKey]::OpenRemoteBaseKey($hive, $hostname)
$applist = $regconnection.OpenSubKey($regkey).GetSubkeyNames()
foreach ($key in $applist) {
    $app = $regconnection.OpenSubKey($regkey+$key)
    $valuenames = $app.GetValueNames()
    $dn = @{}
    foreach($valuename in $valuenames) {
        if ($valuename -eq "DisplayName") {
            $table.Add($valuename, $app.GetValue($valuename))
        }
    }
    $dn
}
#$soft.GetValueNames() | Select-Object @{Name = "Name"; Expression = {$_}},
#@{Name = "Value"; Expression = {$soft.GetValue($_)}}