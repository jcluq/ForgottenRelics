Game Design Document
--------------------

**Name of the Game: Forgotten Relics**

**Link to the game repository: https://github.com/jcluq/ForgottenRelics**

-   based on DOI: 10.1109/CGames.2012.
-   Date: 01/
-   Tutorial: Name of the Student: Juan Camilo Luque
-   1 Overview Table of content
-   1.1 Game abstract
-   1.2 Objectives to be achieved by the game
-   1.3 Core gameplay
-   1.4 Game features
    -   1.4.1 Genre
    -   1.4.2 Number of players
    -   1.4.3 Game theme
    -   1.4.4 Story summary
-   2 Mechanics
-   2.1 Game elements categories
-   2.2 Rules
    -   2.2.1 Interaction rules
    -   2.2.2 Artificial Intelligence
-   2.3 Game world elements
-   2.4 Game log elements
-   2.5 Other elements
-   2.6 Assets list
-   3 Dynamics
-   3.1 Game World
    -   3.1.1 Game theme details
    -   3.1.2 Missions/levels/chapters Flow
-   3.2 Missions/levels/chapters elements
    -   3.2.1 Objectives
    -   3.2.2 Rewards
    -   3.2.3 Challenges
-   3.3 Special areas
-   3.4 Game interface
-   3.5 Controls interface
-   3.6 Game Balance
-   4 Visuals and Sounds
-   4.1 Game visuals
-   4.2 Game sounds
-   5 Document information
-   5.1 Definition, acronyms and abbreviations.
-   5.2 Document references.
-   6 Attachments

1 Overview
----------

### 1.1 Game abstract

Forgotten Relics is a Tactical turn-based IsometricRPG game. The game takes place in a fantasy medieval world in which magic and magicalcreatures exist.

### 1.2 Objectives to be achieved by the game

The game pretends to be a great tactical RPG thatis able to apply many of the great mechanics found on the genre. It purposes fun by the storytellingand the customization of characters, making them stronger and specialized by interactingwith the class system.

### 1.3 Core gameplay

The game is an isometric tactical RPG which meansit is a turn-based space driven combat game. Combats happen on limited terrain areas in whichthe player uses his characters to fight with the enemy characters. The characters take turnsto move and attack.

### 1.4 Game features

The player has a party of up to 5 characters. Eachof these have attributes, which define the strengths of the character. These are INT, STR andDEX. They gain attribute points as they level up. This attributes determine character attackclass, and also give advantages to characters ( i.e. High dexterity = more movement,dodging chance)

Each character has a class based on these scores.Classes define the type of abilities the character has. The class system uses a rock paperscissors scheme in which attributes beat and are beaten by another attribute, it follows theorder INT\>STR\>DEX\>INT. Classes are specializations in one of these 3 attributes, or acombination of two of them. A 3 attribute class is also planned.

Maps have terrain, on which characters may find movelimitations or height advantage/disadvantage. On the isometric map, a 1*1*1cube represents a unit of height. Terrain is placed on 1*1*.5 tiles. A character canmove .5 in the z axis without penalization. Moving 1 in the axis give a penalization unless youhave an high DEX stat.

Some weapons give special abilities which work basicallythe same as class abilities.

#### 1.4.1 Genre

The game is a Tactical RPG, as it involves turn-basedcombat in a fixed combat zone. Movement and action points are implemented. RPG elementssuch as character attributes, equipment and level.

#### 1.4.2 Number of players

The game is thought of as a single player game, yet,a two player setup could also be implemented due to how the combat system is thought.

#### 1.4.3 Game theme

There are two approaches: having a fantastical middleages setup or a steampunk/Skypunk aesthetic.

#### 1.4.4 Story summary

Valad is asked to explore a cave in which disturbanceshave been reported. He goes and finds a guy mining. The guy dogs a chest with a weird weirdbow inside. He realized he was being watched and attacked. Valad defeats the guy, who wasvery tired. He capture the guy and keeps the bow. As the story keeps developing, Valad startsmeeting people who tell him about the bow. The guy they had captured is part of an evil organizationlooking ancient weapons to throw a war against Demeria the country in which all takesplace.

2 Mechanics
-----------

### 2.1 Game elements categories

Playable character: each character who is part ofyour party is considered a playable character. You can manage their equipment, their stats and theirclasses, as well as commanding them in the battlefield. They have Hit Points and AbilityPoints, aswell as experience and levels.

Non playable characters (NPCs): all characters notcontrolled by the player: quest givers, merchants and enemies.

Quests: The game progresses as the player completesquests. These quests are what make combat scenarios available. They are given to theplayer by NPCs in the non combat scenario. They reward the player with experience, items and/orgold.

Battleground (combat scenario) : the battlegroundis where the combat happens. Most of the game happens in this scenario. The map changes dependingon the quest. While in the combat scenario, characters take turnsand select actions on each of their turns. Possible actions are: moving, attacking, using anability, using an item or waiting.

Inn (non combat scenario): in the inn, the playerreceives quests, recruit troops, trade items and equip their characters. In this place movement isfree, so no turns are required to move and interact.

Equipable items: Weapons and armor, they can be equippedby playable characters. Series they require specific class, level and/or attributescore to be equipped. Some can give the characters. This can be rewarded by quests, end ofbattle spoils,

Consumable Items: items that have a single use. Theseitems can be used in battle. They can heal or provide boosts to the characters.

Quest items: items given in quests that interact withthe map. Can be used in combat.

### 2.2 Rules

Characters have 3 main attributes: Strength (STR),Dexterity (DEX)and Intelligence(INT). Theseattributesdeterminehowhardthecharacterhitsandhowmuchdefenseithasdepending on the weapon and class he is using. This specs alsohave different bonuses: (STR = +Health) (DEX = + Movement / Dodge chance) (Int = + ActionPoints).

Charactershavelevels whichareincreasedbyearningexperiencepoints.Whencharacters level up, they can increase two points of their attributes.

Charactershaveclasses,whichareselecteddependingonthecharacter’slevelandattributes. ThethreefirstclassesareMage,ArcherandWarrior.Ascharactersbecomestronger,theycan

changetheirclassestobecomestronger.Strongerclassesareaspecializationofoneofthe Mage-Archer-Fighter classes, or also combinationsbetween them.

Examples: (Archer + Fighter = Rouge) (Archer + Archer = Ranger) (Mage + Fighter = Battlemage) (Fighter + Fighter = Plate Tank / 2H fighter) etc...

Characters have abilities which can be used in combat.To use them, the character must spend AP according to the ability AP cost. Classes and itemsmake different abilities available for each character.

**Combat rules:** Atthebeginningofcombat,theplayerpositionshischaractersona"startingzone"whichisa limited space of the map. Each placed character beggingthe fight with full HP and AP.

A character turn follows the following steps:

1.  Move.Acharacterisabletomovetoanothervalidsquareinthemap.Themovement range depends on the character'sDEXattribute.Differences interrainalso limitthe character'smovement.Ifatargetpositionis 1 blockorhigherthanthecurrentcharacter position, it won't be able to move in there unless he passes a certain dexterity requirement.
2.  Use items. A character can use one object of theirinventory instead of moving.
3.  Acharactercanalwaysperformanoffensiveaction.Thisiseathieranormalattackoran ability.AbilitiesarespecialattackswhichcostAP. Asubmenushowingthecharacter availableabilitieswillopenattheactionpanelwhentheactiontabisselected. Attacking always ends your turn.
4.  Ifacharacterdoesnotdesiretoperformanactionoronlyoneofthem,hecanusethe wait option to finish his turn.

When a turn ends, the turn chart changes, moving thecurrent character to last.

Thecombat willlast untilallthe characters ofateamaredefeated.Aftercombatacombat summaryscreen willbedisplayed,showingrewardsfromcombatandexperiencegainedfor each of your units.

#### 2.2.1 Interaction rules

In combat, characters haveHealthPoints(HP),ActionPoints(AP). HPindicates character health.When it reaches 0, the characterisK.O..APindicates thenumber of Abilitypoints. Abilitiesuseabilitypoints.ThecharacterhaveAbilitypointsdependingontheirINTspecand class bonuses.

Whenattacking,arangeindicatorshowsthevalidtargetsfortheattackorabilityselected.This willvarydependingonthetypeoftheabilityandthesourceofdamage,alsochangesifitis melee, ranged or an area over effect attack.

Whenanormalattack ismadethe baseattackof acharacteris calculatedwiththe target defenses. The difference between both is the possible damage output. Attacks receive advantage depending on their target on the following logic: melee\>ranged\>magic\>melee. Dexterity adds a possibility of dodging the attack.

Abilitiesusually hitharderorgiveextra effectssuch asbuffsorrebuffstotargets.Damage mitigation is also possible on abilities.

Characters areableto equipitems.They canequiparmor, 1hweapons, 2hweapons, and shields.Strongeritemsrequire certainpointsonadeterminedattribute,orthecharactertobe of a specific class. Some weapons and armor can grantabilities too.

Characters can also use consumable items for restoringHP and AP, or buffing their attributes.

#### 2.2.2 Artificial Intelligence

An AI system is planned to have a single difficulty.Better characters and equipment for AI is what increases difficulty.

### 2.3 Game world elements

Thegameisalwaysalternatingbetweentheinn(orcamp?)( **noncombatscenario** )andthe battleground ( **combat scenario** ).

The **non-combat scenario** is an isometric space with different NPCs.The character can interactwiththeseNPCsinordertobuyitems,receivequests,save,andotherquestrelatedor atmospheric interactions. These interactions opendialogs between the characters.

Therearetwovendorsinthisarea:theInnkeeperandtheshopvendor.Theinnkeeperallows thegametobesavedandcanbringupquests.Theshopvendorallowsyoutoaccesstheshop, in which you can buy or sell items.

The **combat scenario** is an isometric space with different variations on the terrain. The dimensions and variations change according to thequest/narrative elements needed.

Inthecombatscenariowefindaturntrackerontheleftuppermostcorner,acurrentcharacter informationpanelandaturnactionspanel.Atargetinformationpanelpromptswhenacharacter is being targeted by the current turn character.

A map could be implemented to organize combat scenariosand give them a place on a larger world. When leaving the inn, the map would promptand the player would select the place on the map on which he has his next quest.

### 2.4 Game log elements

When a character levels up, he is given points onhis character sheet to put on any attribute he wants. A small sign will appear in the interface.

When combat is finished, a reward screen shows thespoils of combat: EXP, GOLD and items earned, as well as if any character levels up.

### 2.5 Other elements

**Cutscenes./ Narrative Events**

Incertainmoments, cutsceneshappenintheformofrectanglesonthescreen.Thesedialogs contain the name of the character who is speaking.

### 2.6 Assets list

Character Sprites Item Sprites Non Combat Scenario Combat Scenarios In-Combat character sheet In-Combat turn order sprites

In-Combat action interface Character Sheet Store Interface Inventory Interface Start Menu Interface Dialog Interface

3 Dynamics
----------

### 3.1 Game World

The game takes place in a medieval fantasy setup inwhich magic exists. The game happens in the Denarian Empire, a vast kingdom in the south continentof Haal.

A Skypunk/Steampunk setup is also appealing for thegame, yet assets would be harder to make.

#### 3.1.1 Game theme details

The game is set on an isometric camera view. Combatand non combat scenarios contain elements that decorate the locations accordingly,for example, a forest would have some trees (which would also act as obstacles), a river, andgreen tiles. On the other hand, the non combat scenario will have tables, various NPCs hanging aroundin the place, vendors, and pub-like decoration.

#### 3.1.2 Missions/levels/chapters Flow

The game is always alternating between the non combatscenario and combat scenarios. In the NCS, characters can buy/sell items, interact withNPCs and accept quests. After accepting quests, they can leave the NCS and go to the correspondentCS for the quest.

A more open approach to the CS selection could bepossible, as well as a secondary quest system. For this, a CS selection screen would be needed,this could be represented as a map.

### 3.2 Missions/levels/chapters elements

#### 3.2.1 Objectives

When quests are accepted, an objective will indicate what the player has to do. This usually involves going to a CS and doing what is requested.The player will be asked to investigate, kill a character, obtain an item, or use an item at a specificlocation.

#### 3.2.2 Rewards

When the player has success on the CS (winning thefight or accomplishing objective), a reward screen will appear. The obtainable rewards can bepart of the quest rewards, but also could be a random item dropped by an enemy. Possible rewardsinclude Equipable items, consumable items and/or gold. Experience gains are also shownin this screen.

#### 3.2.3 Challenges

As the characters level up and the story develops,enemy characters also become harder to defeat, as their stats and items are also increasedas the story develops.

Some important characters will outpower the playercharacter’s, by being of higher levels, this may be considered a boss fight.

Some battles can have a single character that is alot mor strong than the players character, yet this character would be the only enemy. This encounterswould require a high strategic thinking of the player.

### 3.3 Special areas

Non Combat Scenario is an special area, see 2.1 and2.

### 3.4 Game interface

**Character sheet**

Youcanaccessthecharacter'ssheetsbypressingthestartmenuandselectingthecharacter tab.Onthisscreenyoucanseeinformationaboutthecharacters.Theinformationavailableis: Name, level,class,attributes,andattackanddefensescores.Therearetwobuttonsonthis menu:changeclass,whichwilltakeyoutotheclassselectionscreenandtheequippeditems button, which will show you a list of the currentcharacter's equipped items.

**Class selection screen.**

Theclass selectionscreen isaninterfaceforselectingyourcharacter'sclass.Itwillshowa triangularstructurewhichhassubdivisionsamongit.Thethreeattributes,STR,DEXandINT representeachcornerofthetriangle.Inthesubdivisionswefindtheclass.Thiscanalsobe referredtoastheclasstree.Acharactermustmeetclassrequirementsinordertochangetheir class. On each subdivision of the triangle, a sprite with the respective class(visual representationoftheclass).Availableclassesforswitchingwillbefullcolored,whileunavailable classes will be darkened out.

**Inventory screen.**

The inventory screen canbe accessed by the start menu.The inventory screenprovides information about the items you currently own. The interface is separated into 4 main components.

The tab selector allowsyoutodisplay itemlistswhichdivideyour items into 4 categories: Weapons, Armor, Consumables and Quest Items.

Theitemlist allowsyoutonavigatethrough youritems.Youcanselectanitemtohaveit's name,pictureanddescriptionshown.Youcanalsoselectanitemanddestroyitbyselectingthe corresponding option

**Name and picture:** it shows the name and picture ofthe selected item on the list.

**Description** :itshowsthedescriptionofthecurrentselecteditem.Informationaboutstartbuffs appears here.

**Shop Screen** Similartotheinventoryscreen,theshopsalsocontain 4 differentsections:tabselector,itemlist, name and picture, and description.

Thetabselectorallowsyoutonavigatethroughthebuyandselltab.Thebuytapshowsthe vendor available items. The sell tab shows all ofyour sellable items.

Theitemlist allowsyoutonavigatethrough youritems.Youcanselectanitemtohaveit's name, picture and description shown. Selecting an item will print a confirmation for buying/selling.

**Name and picture:** it shows the name and picture ofthe selected item on the list.

**Description** :itshowsthedescriptionofthecurrentselecteditem.Informationaboutstartbuffs appears here.

**Other Screens.**

Viathestartbutton,wecanaccessothertabssuchasoptions,abilitiesandmap.Thishavenot been mapped yet, so they are only mentioned as a futureimplementation.

### 3.5 Controls interface

Screens are usually manipulated by the arrow buttons,with a tab/button navigation system. Selection would be made with button “1” and cancelwith button “2”.

As the interfaces open submenus, this makes navigationintuitive and easy to operate.

### 3.6 Game Balance

The rock - paper - scissors mechanic between the3 attributes is applied in order to create balance and build a party that can supply and adaptto different challenges. A lost combat could have a different outcome if the player prepares hisparty for a specific battle. If a player has 2 Warriors and has to fight 2 mages, it is very probablehe will lose. The player must change his characters or buy consumables in order to overcomethe challenge.

4 Visuals and Sounds
--------------------

### 4.1 Game visuals

When on CS and NCS, the player is always seeing atleast one character on screen. Idle characters have a small sprite animation. When charactersmove, they change their sprites animations to mimic movement. Map movement is notneeded, as scenarios aren’t meant to change.

When attacking, the character performs an attack animation,which is often swinging his weapon. Special Abilities create different animationsdepending on the ability. A fireball for example would show a fireball being casted from thecharacter to the enemy.

Dialog windows show text that allows you to communicatewith NPCs, this is shown in the form of streams of texts.

### 4.2 Game sounds

Game has ambiental music which corresponds to thecontext of the player location and/or event. For CS fast paced music is preferred, whilein NCS a more rhythmic, relaxing music is preferred.

Selecting abilities and attacking also produces sounds. Performing abilities and attacking do sounds thataccompany the action.

5 Document information
----------------------

### 5.1 Definition, acronyms and abbreviations.

    Term or abbreviation Definition and acronyms

    STR Strength

    DEX Dexterity, Agility

    INT Inteligence

    CS Combat Scenario

    NCS Non Combat Scenario

    NPC Non Playable Character

### 5.2 Document references.

6 Attachments
-------------
