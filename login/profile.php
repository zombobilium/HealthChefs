<!doctype html>
<html lang="en">

	<head>
    <meta charset="utf-8">

    <!-- Always force latest IE rendering engine or request Chrome Frame -->
    <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- Use title if it's in the page YAML frontmatter -->
    <title>HealthChef Data View Page</title>

    <link rel="stylesheet" href="css/profile.css">



	
	
  </head>

  <body>
  <!--   Table format credits on  http://codepen.io/jordyvanraaij/pen/jlAqp -->
  
    <script>
	
	
	var hideshow1 = false;
	var hideshow2 = false;
	var hideshow3 = false;
	var hideshow4 = false;
	
	
	function myFunction1(){
		hideshow1 = !hideshow1;
		console.log("entrou no myfunc 1");
		if(hideshow1) {
			console.log("if true");
			document.getElementById("target1").style.display = 'block';
		}
		else
		{
			console.log("if false");
			document.getElementById("target1").style.display = 'none';
		}
	}
	
	function myFunction2(){
		hideshow2 = !hideshow2;
		console.log("entrou no myfunc 2");
		if(hideshow2) {
			console.log("if true");
			document.getElementById("target2").style.display = 'block';
		}
		else
		{
			console.log("if false");
			document.getElementById("target2").style.display = 'none';
		}
	}
	
	function myFunction3(){
		hideshow3 = !hideshow3;
		console.log("entrou no myfunc 3");
		
		if(hideshow3) {
			console.log("if true");
			document.getElementById("target3").style.display = 'block';
		}
		else
		{
			console.log("if false");
			document.getElementById("target3").style.display = 'none';
		}
	}
	
	function myFunction4(){
		console.log("entrou no myfunc 4");
		hideshow4 = !hideshow4;
		
		if(hideshow4) {
			console.log("if true");
			document.getElementById("target4").style.display = 'block';
		}
		else
		{
			console.log("if false");
			document.getElementById("target4").style.display = 'none';
		}
	}
 
    </script>
  <?php 
  
		include_once("connection.php");
		session_start();
		
		// Row 1 of Table 1
		$stmt =$db->prepare('SELECT COUNT(*) As facil FROM "public"."Login" WHERE data BETWEEN now()- INTERVAL \'7 day\' AND now() ;');  /* Starts from the past to the future*/
		$stmt->execute();
		$lastweek = $stmt->fetch();
		
		$stmt2 =$db->prepare('SELECT COUNT(*) As facil FROM "public"."Login" WHERE data BETWEEN now()- INTERVAL \'31 day\' AND now() ;');
		$stmt2->execute();
		$lastmonth = $stmt2->fetch();
		
		$stmt3 =$db->prepare('SELECT COUNT(*) As facil FROM "public"."Login"');
		$stmt3->execute();
		$always = $stmt3->fetch();
		
		// Row 2 of Table 1
		// SELECT column where each user has oldest login in last week 
		
		$stmt4 =$db->prepare('SELECT COUNT(*) As facil FROM(
		SELECT mt.* FROM "public"."Login" As mt INNER JOIN
    (
        SELECT "public"."Login"."idUser", MIN(data) As MinDate
        FROM "public"."Login"
        GROUP BY "public"."Login"."idUser"
    ) t ON "mt"."idUser" = "t"."idUser" AND mt.data = t.MinDate
	) As mmt
	WHERE data BETWEEN now()- INTERVAL \'7 day\' AND now()');
		$stmt4->execute();
		$lastweekregs = $stmt4->fetch();
		
		
		// SELECT column where each user has oldest login in last month
		
		
		$stmt5 =$db->prepare('SELECT COUNT(*) As facil FROM(
		SELECT mt.* FROM "public"."Login" As mt INNER JOIN
    (
        SELECT "public"."Login"."idUser", MIN(data) As MinDate
        FROM "public"."Login"
        GROUP BY "public"."Login"."idUser"
    ) t ON "mt"."idUser" = "t"."idUser" AND mt.data = t.MinDate
	) As mmt
	WHERE data BETWEEN now()- INTERVAL \'31 day\' AND now()');
		$stmt5->execute();
		$lastmonthregs = $stmt5->fetch();
		
		// SELECT column where each user has oldest login SINCE Always
		
		$stmt6 =$db->prepare('SELECT COUNT(*) As facil FROM(
		SELECT mt.* FROM "public"."Login" As mt INNER JOIN
    (
        SELECT "public"."Login"."idUser", MIN(data) As MinDate
        FROM "public"."Login"
        GROUP BY "public"."Login"."idUser"
    ) t ON "mt"."idUser" = "t"."idUser" AND mt.data = t.MinDate
	) As mmt');
		$stmt6->execute();
		$alwaysregs = $stmt6->fetch();
		
		
		// Number of hours average played
		
		$stmt7 = $db->prepare('SELECT AVG(numberhours) As facil FROM "public"."User"');
		$stmt7->execute();
		$avghoursplayed = $stmt7->fetch();
		
		//Each minigame highscore  Minigame1
		
		$stmt8 = $db->prepare('SELECT MAX("MiniGame"."highScore") As MHS FROM "public"."MiniGame" WHERE "MiniGame"."idGame"=1');
		$stmt8->execute();
		$mg1hs = $stmt8->fetch();
		
		// AND each minigame average times played
		$stmt9 = $db->prepare('SELECT AVG("MiniGame"."timesPlayed") As tp FROM "public"."MiniGame" WHERE "MiniGame"."idGame"=1');
		$stmt9->execute();
		$mg1tp = $stmt9->fetch();
		
		//Each minigame highscore Minigame2
		$stmt10 = $db->prepare('SELECT MAX("MiniGame"."highScore") As MHS FROM "public"."MiniGame" WHERE "MiniGame"."idGame"=2');
		$stmt10->execute();
		$mg2hs = $stmt10->fetch();
		
		// AND each minigame average times played
		$stmt11 = $db->prepare('SELECT AVG("MiniGame"."timesPlayed") As tp FROM "public"."MiniGame" WHERE "MiniGame"."idGame"=2');
		$stmt11->execute();
		$mg2tp = $stmt11->fetch();
		
		//Each minigame highscore Minigame3
		$stmt12 = $db->prepare('SELECT MAX("MiniGame"."highScore") As MHS FROM "public"."MiniGame" WHERE "MiniGame"."idGame"=3');
		$stmt12->execute();
		$mg3hs = $stmt12->fetch();
		
		// AND each minigame average times played
		$stmt13 = $db->prepare('SELECT AVG("MiniGame"."timesPlayed") As tp FROM "public"."MiniGame" WHERE "MiniGame"."idGame"=3');
		$stmt13->execute();
		$mg3tp = $stmt13->fetch();
		
		//Each minigame highscore Minigame4
		$stmt14 = $db->prepare('SELECT MAX("MiniGame"."highScore") As MHS FROM "public"."MiniGame" WHERE "MiniGame"."idGame"=4');
		$stmt14->execute();
		$mg4hs = $stmt14->fetch();
		
		// AND each minigame average times played
		$stmt15 = $db->prepare('SELECT AVG("MiniGame"."timesPlayed") As tp FROM "public"."MiniGame" WHERE "MiniGame"."idGame"=4');
		$stmt15->execute();
		$mg4tp = $stmt15->fetch();
		
                        
    ?>
	<h1><img src="css/basictitle.png" width="30%" height="30%" /></h1>

	<table>
	
	  <tr>
		<!--<th>Main driver</th>-->
		<th data-th="Driver details"><span><h2>Property</h2></span></th>
		<th><h2>Last week</h2></th>
		<th><h2>Last month</h2></th>
		<th><h2>Total</h2></th>
	  </tr>
	  
	  <tr>
		<td><h4>Number of Logins:</h4></td>
		<td><?php echo $lastweek['facil'];  ?></td>
		<td><?php echo $lastmonth['facil']; ?></td>
		<td><?php echo $always['facil'];    ?></td>
	  </tr>
	  
	  <!--<tr>
		<td><h4>Number of hours played: </h4></td>
		<td>Foo</td>
		<td>01/01/1978</td>
		<td>Spouse</td>
	  </tr>-->
	  
	  <tr>
		<td><h4>Number of [Registered] Players: </h4></td>
		<td><?php echo $lastweekregs['facil'];  ?></td>
		<td><?php echo $lastmonthregs['facil'];  ?></td>
		<td><?php echo $alwaysregs['facil'];  ?></td>
	  </tr>
	  
	  <tr>
		<td><h4>Number of Average Played Hours: </h4></td>
		<td> - </td>
		<td> - </td>
		<td><?php echo round($avghoursplayed['facil'],2);  ?></td>
	  </tr>
	</table>
	  <br/> <br/> <br/> <br/>
	  
	  
	  <!-- Minigame 1 -->
	  <button onClick="myFunction1()">MiniGame1</button>
	  <div style="display: none;" id="target1">
		  <table>
		  <tr>
		<!--<th>Main driver</th>-->
			<th data-th="Driver details"><span><h2>MiniGame 1</h2></span></th>
		  </tr>
		  <tr>
			<td><h4>HighScore: </h4></td>
			<td><?php echo $mg1hs['mhs'];  ?></td>
		  </tr>
		  <tr>
			<td><h4>Average Times Played: </h4></td>
			<td><?php echo round($mg1tp['tp'],2);  ?></td>
		  </tr>
		  </table>
	  </div>
	  
	  
	  
	   <!-- Minigame 2 -->
	   <button onClick="myFunction2()">MiniGame2</button>
	  <div style="display: none;" id="target2">
		  <table>
		  <tr>
		<!--<th>Main driver</th>-->
			<th data-th="Driver details"><span><h2>MiniGame 2</h2></span></th>
		  </tr>
		  <tr>
			<td><h4>HighScore: </h4></td>
			<td><?php echo $mg2hs['mhs'];  ?></td>
		  </tr>
		  <tr>
			<td><h4>Average Times Played: </h4></td>
			<td><?php echo round($mg2tp['tp'],2);  ?></td>
		  </tr>
		  </table>
	  </div>
	  
	  
	  
	   <!-- Minigame 3 -->
	   <button onClick="myFunction3()">MiniGame3</button>
	  <div style="display: none;" id="target3">
		  <table>
		  <tr>
		<!--<th>Main driver</th>-->
			<th data-th="Driver details"><span><h2>MiniGame 3</h2></span></th>
		  </tr>
		  <tr>
			<td><h4>HighScore: </h4></td>
			<td><?php echo $mg3hs['mhs'];  ?></td>
		  </tr>
		  <tr>
			<td><h4>Average Times Played: </h4></td>
			<td><?php echo round($mg3tp['tp'],2);  ?></td>
		  </tr>
		  </table>
	  </div>
	  
	  
	  
	   <!-- Minigame 4 -->
	   <button onClick="myFunction4()">MiniGame4</button>
	  <div style="display: none;" id="target4">
		  <table>
		  <tr>
		<!--<th>Main driver</th>-->
			<th data-th="Driver details"><span><h2>MiniGame 4</h2></span></th>
		  </tr>
		  <tr>
			<td><h4>HighScore: </h4></td>
			<td><?php echo $mg4hs['mhs'];  ?></td>
		  </tr>
		  <tr>
			<td><h4>Average Times Played: </h4></td>
			<td><?php echo round($mg4tp['tp'],2);  ?></td>
		  </tr>
		  </table>
	  </div>
	  

	</body>
</html>