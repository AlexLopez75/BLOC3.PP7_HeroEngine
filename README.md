# 🛡️ Chapter 1: El Consell dels Herois — Jerarquia de classes

Aquest readme detalla els resultats d'executar un joc de proves a la clase base AHero i les subclasses Warrior, Mage i Rogue. 

---

## 1. Estat inicial (Greeting / ToString)

Creant els personatges dona els següents resutalts:  

Warrior: [Warrior] Link | Level: 1 | HP: 150/150 | Power: 30 | Armor: 40 | Battle Cry: 'Hyaa!'  
Mage: [Mage] Ela | Level: 1 | HP: 200/200 | Power: 20 | Mana: 40/40 | Arch level: 1  
Rogue: [Rogue] Elding | Level: 1 | HP: 170/170 | Power: 15 | Damage multiplier: 3 | Daggers: 10  

## 2. Proves d'atac

Atacant amb els personatges dona els següents resultats:  

> Warrior: Link attacks! Deals 30 damage.  
Mage: Ela attacks! Deals 20 damage.  
Rogue: Elding attacks! -> Base damage: 15, Multiplier: 3 -> Deals 45 damage.  

## 3. Proves de dany rebut

Rebent dany amb Mage i Rogue dona els següents resultats:  

> Mage: Ela receives 30 damage. | HP: 170/200  
Rogue: Elding receives 30 damage. | HP: 140/170  

Atacant al Warrior amb 50 de dany (Armor: 40):  

> Warrior: Link receives 50 damage. -> Armor absorbs 40 damage -> Total damage: 10 | HP: 140/150  

Atacant al Warrior amb 30 de dany (Armor: 40):  

> Warrior: Link receives 30 damage. -> Armor absorbs 40 damage -> Total damage: 0 | HP: 140/150  

## 4. Proves de derrota

El Rogue rep suficient dany com per ser derrotat:  

> Rogue: Elding receives 200 damage. | HP: 0/170  

Si s'intenten fer accions amb el Rogue derrotat:  

> Rogue: Elding is defeated and can't attack!  
Rogue: Elding is defeated and can't receive damage!  

