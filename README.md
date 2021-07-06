aktuelle Version

RespawnSystem angepasst:
- es gibt jetzt ein GameObject, dass als Respawn funktioniert
- Mit Hilfe dieses GameObjects sollte es leicht möglich sein einen zweiten Respawnpoint zu erstellen, falls man diesen erreicht hat.
- Natalias Lebenssystem in GameMaster verschoben und es als public static void angelegt, damit man von überall auf die Funktion "KillPlayer" zugreifen kann. Somit kann auch die DeathZone mithilfe von KillPlayer(player) einfach ein Leben des Spielers abziehen und ihn Respawnen lassen

Main Camera angepasst:
- Camera2DFollow sucht nun nach einem GameObject mit dem Tag "Player" falls das vorherige GameObject zerstört wurde

