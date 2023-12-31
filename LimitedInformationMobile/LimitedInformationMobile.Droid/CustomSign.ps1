& 'C:\Program Files (x86)\Java\jdk1.7.0_55\bin\jarsigner.exe' -verbose -tsa http://timestamp.comodoca.com/rfc3161 -sigalg SHA1withRSA -digestalg SHA1  -keystore C:\Jottacloud\Jottacloud\andriodKeystore  -signedjar ./bin/ObsfucatedRelease/net.limitedinformation.limitedinfo-Signed-Unaligned.apk ./bin/ObsfucatedRelease/net.limitedinformation.limitedinfo.apk "Limited Info"
& 'C:\Program Files (x86)\Android\android-sdk\build-tools\23.0.3\zipalign.exe' -f -v 4 ./bin/ObsfucatedRelease/net.limitedinformation.limitedinfo-Signed-Unaligned.apk ./bin/ObsfucatedRelease/net.limitedinformation.limitedinfo-Signed.apk




& 'C:\Program Files (x86)\Android\android-sdk\platform-tools\adb.exe' install C:\Development\LimitedInformationMobile\LimitedInformationMobile\LimitedInformationMobile.Droid\bin\ObsfucatedRelease\net.limitedinformation.limitedinfo-Signed.apk
pause