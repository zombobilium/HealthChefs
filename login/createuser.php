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
	
	  