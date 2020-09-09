****** APPers *********

Table of Contents: 

1. Concept
2. Structure 
	A) Beers 
	B) Menu (where the customer orders) 
	C) Tab 
3. Future Features
4. Links & Instructions

********************************************************************************************
---------------------------------------1. Concept-------------------------------------------

********************************************************************************************


The APPErs app is an app designed for a Bar. The idea is derived from the arcade bar Tappers (hence the name). We would always say how much better it would be if at Tappers there was an APP that would allow you to order a beer and have it delivered to the arcade, pinball machine, or table that you were at. The original intent was to build a table for Beers to be inventoried, a table for the customer to be able to order the beers, and then queue for the bar to handle orders. Upon building the App, I realized much of the queue features can be handled on the front end, so I made the third table a way for consumers to start a tab and then eventually finalize their bill and "pay" for the tab. 

********************************************************************************************
--------------------------------------2.Structure-------------------------------------------

********************************************************************************************

A) Beers
Key features: 
	BeerId
	TypeOfBeer: (Enum)
	Price
	Description
	Image
	InventoryCount (This is lowered by 1 every time somebody orders a drink)
	InRotation (bool, if there are 0 beers, the beer will not be able to be selectable)

B) Menu:
This table should probably be more appropriately named "Orders," because this is where the customer orders their drinks.

Key Features:
	OrderId
	Select BeerID(fk)
	OrderTotal (derived from price on Beer table)
	OrderDelivered (bool for the bar to mark when this has been delivered)
	TabId (fk, automatically updates tab grandtotal based on tabID given)

C) Tab 
The tab table allows users to create a tab and when they order a drink it will automatically update their grand total. 
	TabId
	GrandTotal
	Signature (used this to signify they paid their bill)
	TabPaid (bool, used this to signify they paid their bill)

********************************************************************************************
--------------------------------------3. Future Features-------------------------------------------

********************************************************************************************

I couldn't quite get things working to just show an admin view. On the front end as you can see a Navigation tab titled "Admin." This is where the bar employees can look at open orders. I wanted to make this admin only. For now, anyone can look at it, but you get the idea. 

********************************************************************************************
--------------------------------------4. Links and Instructions-------------------------------------------

********************************************************************************************

Links: 
Planning Doc: https://docs.google.com/document/d/1VYXud5_oEl2wZWk5TTn8lKCCwLzNA9Tw_ujpUOn56Y8/edit?usp=sharing
Wireframe: https://docs.google.com/spreadsheets/d/1eLQ2sp8n8wxO2irj4cxFPYNqRq8QDCX13HvQF6ZbHEo/edit?usp=sharing


