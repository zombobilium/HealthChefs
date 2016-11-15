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
		$stmt =$db->prepare('SELECT COUNT(*) As facil FROM "public"."Login" WHERE data BETWEEN now()- INTERVAL \'7 day\' AND now() ;');  /* Starts from the past to the future*/
		$stmt->execute();
		$lastweek = $stmt->fetch();
		
		$stmt2 =$db->prepare('SELECT COUNT(*) As facil FROM "public"."Login" WHERE data BETWEEN now()- INTERVAL \'31 day\' AND now() ;');
		$stmt2->execute();
		$lastmonth = $stmt2->fetch();
		
		$stmt3 =$db->prepare('SELECT COUNT(*) As facil FROM "public"."Login"');
		$stmt3->execute();
		$always = $stmt3->fetch();
                        
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
		<!--<td><input type="radio"/></td>-->
		<td><h4>Number of Logins:</h4></td>
		<!-- insert php -->
		<td><?php echo $lastweek['facil'];  ?></td>
		<td><?php echo $lastmonth['facil']; ?></td>
		<td><?php echo $always['facil'];    ?></td>
	  </tr>
	  
	  <tr>
		<!--<td><input type="radio"/></td>-->
		<td><h4>Number of hours played: </h4></td>
		<!-- insert php -->
		<td>Foo</td>
		<td>01/01/1978</td>
		<td>Spouse</td>
	  </tr>
	  
	  <tr>
		<!--<td><input type="radio"/></td>-->
		<td><h4>Number of [Registered] Players: </h4></td>
		<!-- insert php -->
		<td>Foo</td>
		<td>01/01/1994</td>
		<td>Son</td>
	  </tr>
	  
	  <tr>
		<!--<td><input type="radio"/></td>-->
		<td><h4>Number of average hours played per login: </h4></td>
		<!-- insert php with aritmetics -->
		<td>Foo</td>
		<td>01/01/1992</td>
		<td>Daughter</td>
	  </tr>
  
</table>

	</body>
</html>