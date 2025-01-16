# Gewichtsdatenapp_LiveChart

Hallo Prof. Dr. Stuckenholz,
-------------------------------
mit diesem Read me würde ich kurz nur die wichgsten Sache benennen die Sie brauchen damit alles läuft.

Kurzfassung was ich gemacht habe.
Ich habe mit .NET MAUI eine App entwickelt, die auf Android-Geräten läuft. Wenn Sie die App starten, ist es möglich ihre Daten einzugeben und eine Datei wird erstellt (json file) die ihre eingegeben Werte speichert und in dem Werte Tab auflistet und im Grafik tab mit einen Liniendiagramm den Verlauf darstellt. 
Ich habe den Android Simulator mit Pixel 7- Api35 als Simulator genutzt.

Ich weiß ich muss das nicht da Sie das bestimmt sofort erkennen, aber zu Sicherheit gebe ich die Bedingungen der Werte an. 

Weight is > 0 and < 590 
Height is > 0 and < 2.80
Age is > 18 and < 120
Gender != null
 
Im Windows Mode funktioniert , und in Android der . um Dezimalzahlen anzugeben.

(Nur im Fall das die Nuget-Packages nicht gefunden wurden)

-PackageReference Include="CommunityToolkit.Mvvm" Version="8.4.0" 
-PackageReference Include="LiveChartsCore.SkiaSharpView.Maui" Version="2.0.0-rc4.5" 
-PackageReference Include="Microsoft.Maui.Controls" Version="$(MauiVersion)" 
-PackageReference Include="Microsoft.Extensions.Logging.Debug" Version="9.0.0" 

Diese Packages habe ich benutzt und bei LiveChartCore.SkiaSharpView.Maui beachten Sie das es sich um ein Prerelease handelt deswegen include prerelease.

Ein Problem, das meine App noch hat, ist dass nach der Eingabe neuer Werte die Grafik erst korrekt dargestellt wird, wenn man einmal zwischen den Fenstern wechselt (z. B. von "Eingabe" zu "Grafik", dann zu einem beliebigen anderen Fenster und zurück zu "Grafik"). Bisher habe ich dafür noch keine Lösung gefunden.

Wenn es noch wichtige Fragen vor der Prüfung gibt werde ich diese so schnell wie möglich beantworten.











