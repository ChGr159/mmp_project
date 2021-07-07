aktuelle Version

RespawnSystem angepasst:
- es gibt jetzt ein GameObject, dass als Respawn funktioniert
- Mit Hilfe dieses GameObjects sollte es leicht möglich sein einen zweiten Respawnpoint zu erstellen, falls man diesen erreicht hat.
- Natalias Lebenssystem in GameMaster verschoben und es als public static void angelegt, damit man von überall auf die Funktion "KillPlayer" zugreifen kann. Somit kann auch die DeathZone mithilfe von KillPlayer(player) einfach ein Leben des Spielers abziehen und ihn Respawnen lassen

Main Camera angepasst:
- Camera2DFollow sucht nun nach einem GameObject mit dem Tag "Player" falls das vorherige GameObject zerstört wurde

----- Update -------
Checkpoint hinzugefügt:
	- wenn man den Checkpoint erreicht und dann stirbt, wird man nicht am Anfang des Levels respawnt sondern in der Mitte des Levels

Endscreen:
	- im Endscreen funktioniert nun die Funktion des Buttons Hauptmenü

Bugfixes:
	-bei den Collectibles ein "Else, Return" bei der Abfrage, ob das Berührte ein Collectible ist, da er sonst bei jeder  Berührung mit etwas anderem einen Fehler in der Konsole 	ausgab
	-Gegner interaktion auf OnCollisionEnter2D geändert statt OnTriggerEnter2D, damit die Hitboxen besser funktionieren und nicht nur der Kopf des Spielers als Berührpunkt 		funktioniert
	
