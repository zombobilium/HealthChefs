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
	  
	  <!--
	  <tr>
		<td><h4>Number of average hours played per login: </h4></td>
		<td>Foo</td>
		<td>01/01/1992</td>
		<td>Daughter</td>
	  </tr>-->
  
</table>

	</body>
</html>