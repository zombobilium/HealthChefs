# LDSO


## This program is structured in the following format:

### Health Chefs folder:

This folder contains the unity project and its assets(images/scripts/scenes).

The important folders for the project are in the assets folder which has different folders for each function of the app.
* Avatar folder:
	* Contains the scripts, the images and the scenes regarding the avatar. There is only one scene on this folder and its objective is to give the possibility to costumize an avatar. 
	
* Menus folder:
	* Contains the scripts, the images and the scenes regarding the main menus. There are three scenes on this folder, the page that appears on the loading screen of the game, the main menu of the game and the world scene that represents the available minigames.

* Editor folder:
	* Contains the unit tests scripts of the program.

* Minigame 1 folder:
	* Contains the scripts, the images and the scenes regarding the minigame 1. There are two scenes on this folder, the "Minigame1_Menu" scene that shows the user a list of clickable images of vegetables and the "Guess_Scene" that allows the user to guess the name of the vegetable previously clicked.

* Minigame 2 folder:
	* Contains the scripts, the images and the scenes regarding the minigame 2. There is one scene on this folder, the "Fridge" scene that shows the user a fridge, some foods and then asks the user to organize the fridge with the foods.

* Minigame 3 folder:
	* Contains the scripts, the images and the scenes regarding the minigame 3. There is one scene on this folder, the "LunchBox" scene that shows the user an image of a lunchbox and two ingredients and then asks the user to pick the one he should place on his lunchbox.
	

* Minigame 4 folder:
	* Contains the scripts, the images and the scenes regarding the minigame 4. There is one scene on this folder, the "DinnerPlate" scene that shows the user a plate divided into 5 categories, carbohydrates, vegetables, animal proteins, vegetable proteins and fruits and also shows 5 diffente foods. The user then needs to organize the plate by dragging the food to its respective place. 


* Resources folder
	* Contains all the images that are needed on the program. Every images that needs to be dynamically generated needs to be on this folder.

* Server folder
	* Contains the scripts that hold the information that is needed to send to the server and send this information to the server aswell.

* Settings folder
	* Contains the scripts, the images and the scenes regarding the settings menu. Theres is one scene on this folder, the "Settings" scene that allows the user to turn on/off the music and the sound of the game. The sound option deactivates clicking, correct and incorrect sound effects.

* Sounds folder
	* Contains the sounds used on the program.

* Teste folder
	* Contains the scripts and the scenes regarding the "timeout". There is only one scene on this folder, the "Timeout" scene and this is the scene the user sees after playing for too long. (2hrs/day)

* UnityTestTools folder
	* Default folder that contains the framework for the unit tests on the Editor folder.

### Login folder:

This login folder contains the necessary php and css files for the website and webservices.

The website and webservices are prepared for a database with the following format, in postgres:

Schema: public;

Tables and their respective columns:

* Admins(This Admins table has the necessary login info for the website login page)
	* password;
	* salt;
	* idUser;
	* admin;
	* username;







* Login(This table identifies each login - if possible - as in each start of the application)
	* idLogin
	* idUser
	* data 

* MiniGame(Stores all minigames info)
	* idGame
	* idUser
	* gameName
	* highScore
	* timesPlayed
	* description

* User(A user "device" is stored here)
	* idUser
	* numberofhours





