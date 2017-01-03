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
  
  <?php 
  
  // WHERE "User"."idUser" = (SELECT MAX("User"."idUser") FROM "public"."User");
		include_once("connection.php");
		session_start();
		
		// Row 1 of Table 1
		$stmt =$db->prepare('Insert Into "public"."User"(numberhours) Values(0) RETURNING "User"."idUser"');
		$stmt->execute();
		$result = $stmt->fetch();
		
		
      echo $result['idUser'];	                  
    ?>
	
	  

	</body>
</html>