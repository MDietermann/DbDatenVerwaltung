# Datenbank Importer/Exporter

---

<!-- TOC -->
* [Datenbank Importer/Exporter](#datenbank-importerexporter)
  * [Ziel](#ziel)
  * [Generelle Informationen](#generelle-informationen)
  * [Startseite](#startseite)
    * [Anzeige für Datenbanken](#anzeige-für-datenbanken)
  * [Datenbank-Import](#datenbank-import)
  * [Datenbank-Export](#datenbank-export)
  * [Benötigte Seiten](#benötigte-seiten)
    * [Startseite](#startseite-1)
    * [Import](#import)
    * [Export](#export-)
    * [Abgeschlossen / Fortschrittsanzeige](#abgeschlossen--fortschrittsanzeige)
<!-- TOC -->

## Ziel

---

* Importieren von einem oder mehrerer Dateien in bestehende Tabelle oder Erstellen neuer Tabellen
* Exportieren von einem oder mehrerer Tabellen in eine oder mehrere Dateien

## Generelle Informationen

---

- Programmierung in C# / XAML
- .NET Framework
- WPF-Framework

## Startseite

---

### Anzeige für Datenbanken

* Wenn DB verbunden, anzeigen welche Datenbanken vorhanden sind
    * Möglichkeit, Datenbanken abzumelden
* Wenn keine DB verbunden, anzeigen, dass keine DB verbunden ist
    * _Datenbank hinzufügen_ Button anzeigen

## Datenbank-Import

--- 

* Dropdown-Menü mit allen Datenbanken, die verbunden sind
* Datei-Dialog öffnen und _.csv, .json_ Datei auswählen
* Nach Auswahl einer gültigen Datei und einer Datenbank wird _Import Starten_ Button enabled
* Nach Import wird _Import abgeschlossen_ angezeigt (ggf. während des Imports Fortschritt anzeigen)

## Datenbank-Export

---

* Dropdown-Menü mit allen Datenbanken, die verbunden sind
* Bei Auswahl einer Datenbank eine Liste mit allen Tabellen der Datenbank anzeigen
* Bei Auswahl einer mehrerer Tabellen das gewünschte Dateiformat (.csv, .json) auswählen
* Nach Auswahl einer Datenbank und Auswahl einer oder mehrerer Tabellen und des Dateiformats wird _Export Starten_
  Button enabled
* Nach Export wird _Export abgeschlossen_ angezeigen (ggf. während des Imports Fortschritt anzeigen)

## Benötigte Seiten

---

### Startseite

- Anzeige für Datenbanken (verbunden/nicht verbunden)
- (optional) Auswahlmenü für Tabellen (wenn keine ausgewählt, neu anlegen)
- Auswahl Import/Export

### Import

- Auswahlmenü für Datenbank
- Auswahlmenü für Datei(en)
- _Import Starten_ Button

### Export 

- Auswahlmenü für Datenbank(en)
- Auswahlmenü für Tabellen
- Auswahlmenü für Dateiformat
- _Export Starten_ Button

### Abgeschlossen / Fortschrittsanzeige

- Zeigt Fortschritt des Imports/Exports an
- Zeigt Erfolg/Fehler an
- Button zum Schließen der Anzeige und zurück zur Startseite
