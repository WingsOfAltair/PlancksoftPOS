# Creates a self-signed cert with IP SAN (compatible syntax)
$ip = "192.168.1.29"
$notBefore = Get-Date "2019-01-01"
$notAfter  = Get-Date "2029-01-01"

$cert = New-SelfSignedCertificate `
  -Subject "CN=$ip" `
  -CertStoreLocation "cert:\LocalMachine\My" `
  -KeyExportPolicy Exportable `
  -KeyAlgorithm RSA `
  -KeyLength 2048 `
  -NotBefore $notBefore `
  -NotAfter $notAfter `
  -TextExtension @("2.5.29.17={text}IPAddress=$ip") `
  -FriendlyName "$ip Self-Signed SSL" `
  -Type SSLServerAuthentication

if ($null -eq $cert) {
    Write-Error " Failed to create certificate. Check syntax or run PowerShell as Administrator."
    exit 1
}

# Export PFX
$pfxPath = "C:\temp\${ip}.pfx"
$pwd = ConvertTo-SecureString -String "P@ssw0rd!" -Force -AsPlainText
Export-PfxCertificate -Cert $cert -FilePath $pfxPath -Password $pwd | Out-Null

# Export CRT
$crtPath = "C:\temp\${ip}.crt"
Export-Certificate -Cert $cert -FilePath $crtPath | Out-Null

Write-Host " Created cert:" $cert.Subject
Write-Host "   Thumbprint:" $cert.Thumbprint
Write-Host "   Exported:" $pfxPath "and" $crtPath
