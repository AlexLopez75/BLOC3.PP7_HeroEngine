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


# 🔮 Chapter 2: El Grimori — Sistema d'Habilitats i Màgia

Aquest readme detalla els resultats d'executar el joc de proves per a la classe `Mage` i la seva interacció amb la gestió i llançament d'objectes `Ability`.

---

## 1. Estat inicial (Inventari buit)

Comprovant la llista d'habilitats del personatge Ela just després de ser creada dona el següent resultat:

> Ela has no abilities equiped.

## 2. Proves d'equipament d'habilitats

Equipant noves habilitats a la maga dona els següents resultats:

> [System] Ela equipped 'Fireball'  
> [System] Ela equipped 'Ice shield'  
> [System] Ela equipped 'Mega heal'  
> [System] Ela equipped 'Attack up'  

Si s'intenta equipar una habilitat que ja posseeix a la seva llista:

> [System] Ela has already 'Fireball' equiped

## 3. Llistat d'habilitats (Ordenació i Alineació)

Llistant les habilitats equipades, el sistema les mostra ordenades ascendentment segons el valor de la seva raresa:

> -------------------------------------------------------------------->  
> Ela's Abilities  
> -------------------------------------------------------------------->  
> [COMMON]       Ice shield         | Type: Defense  | Cost:  5 mana  
> [RARE]         Fireball           | Type: Attack   | Cost: 15 mana  
> [EPIC]         Mega heal          | Type: Healing  | Cost: 25 mana  
> [LEGENDARY]    Attack up          | Type: Support  | Cost: 40 mana  
> -------------------------------------------------------------------->  

## 4. Proves de dany i llançament de curació

La maga rep dany per reduir la seva vida i posteriorment llança una habilitat de curació, respectant sempre el límit de la seva vida màxima (200 HP):

> [Mage] Ela | Level: 1 | HP: 160/200 | Power: 20 | Mana: 80/80 | Arch level: 1  
> Activating 'Mega heal' [EPIC]...  
> Ela heals 65 damage.  
> [Mage] Ela | Level: 1 | HP: 200/200 | Power: 20 | Mana: 55/80 | Arch level: 1  

## 5. Proves de llançament de defensa i atac

Es fan llançaments consecutius de defensa (que n'augmenten l'estadística) i d'atac (que sumen el poder base de la maga més el de l'habilitat). Els recursos de manà s'esgoten progressivament:

> [Mage] Ela | Level: 1 | HP: 200/200 | Power: 20 | Mana: 55/80 | Arch level: 1  
> Activating 'Ice shield' [COMMON]...  
> Ela shields itself from 25 damage.  
> [Mage] Ela | Level: 1 | HP: 200/200 | Power: 20 | Mana: 50/80 | Arch level: 1  
> Activating 'Fireball' [RARE]...  
> Ela deals massive damage -> Total damage: 60  
> [Mage] Ela | Level: 1 | HP: 200/200 | Power: 20 | Mana: 35/80 | Arch level: 1  

## 6. Proves d'esgotament de Manà

La maga intenta llançar la seva habilitat Llegendària 'Attack up' (Cost: 40), però només li queden 35 punts de manà després del combat anterior, fent que l'acció falli:

> Ela can't cast 'Attack up' beacuse it doesn't have enough mana! (Needs 40, has 35)