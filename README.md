# LDSO


This program is structured in the following format:

Health Chefs folder:





Login folder:

This login folder contains the necessary php and css files for the website and webservices.

The website and webservices are prepared for a database with the following format, in postgres:

Schema: public;

Tables and their respective columns:
*Admins   // This Admins table has the necessary login info for the website login page.
	- password;
	- salt;
	- idUser;
	- admin;
	- username;
*Login   // This table identifies each login - if possible - as in each start of the application.
	- idLogin
	- idUser
	- data 

*MiniGame     // Stores all minigames info.
	- idGame
	- idUser
	- gameName
	- highScore
	- timesPlayed
	- description

*User    // A user ("device") is stored here
	- idUser
	- numberofhours





