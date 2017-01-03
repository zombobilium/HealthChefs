  <?php 
  echo $_POST['gameID'];
  echo $_POST['userID'];
  echo $_POST['gameName'];
  echo $_POST['highScore'];
  echo $_POST['timesPlayed'];
  echo $_POST['description'];
  
  
  include_once("connection.php");
		session_start();
		
		// Row 1 of Table 1
	/*	$stmt =$db->prepare('begin tran
if exists (select * from table with (updlock,serializable) where idGame = :gid)
begin
   update "public"."MiniGame" set descricao="mudou com sucesso"
   where idGame = 1
end
else
begin
   insert into "public"."MiniGame" (idGame, idUser, description)
   values (:gid,:uid,"foi po else")
end
commit tran');*/
		/*$stmt =$db->prepare('if exists (select * from table with (updlock,serializable) where idGame = :gid)
		begin
		   update "public"."MiniGame" set descricao="mudou com sucesso"
		   where idGame = 1
		end
		else
		begin
		   insert into "public"."MiniGame" (idGame, idUser, description)
		   values (:gid,:uid,"foi po else")
		end');*/
		$gid = 1;
		$uid = 430;
		$stmt = $db->prepare('SELECT COUNT(*) AS cnt FROM "public"."MiniGame" WHERE "MiniGame"."idGame" = :gid AND "MiniGame"."idUser" = :uid');
		$stmt->bindParam(':gid', $_POST['gameID']);
		$stmt->bindParam(':uid', $_POST['userID']);
		$stmt->execute();
		$result = $stmt->fetch();
		
		if ($result['cnt']==0){
			$stmt2 = $db->prepare('INSERT INTO "public"."MiniGame" Values (:gid, :uid, :gn, :hs, :tp, :ds)');
			$stmt2->bindParam(':gid', $_POST['gameID']);
			$stmt2->bindParam(':uid', $_POST['userID']);
			$stmt2->bindParam(':gn', $_POST['gameName']);
			$stmt2->bindParam(':hs', $_POST['highScore']);
			$stmt2->bindParam(':tp', $_POST['timesPlayed']);
			$stmt2->bindParam(':ds', $_POST['description']);
			$stmt2->execute();
		}
		else{
			$stmt2 = $db->prepare('UPDATE "public"."MiniGame" SET "idGame"=:gid, "idUser"=:uid, "gameName"=:gn, "highScore"=:hs, "timesPlayed"=:tp, "description"=:ds WHERE "MiniGame"."idGame"=:gid AND "MiniGame"."idUser"=:uid');
			$stmt2->bindParam(':gid', $_POST['gameID']);
			$stmt2->bindParam(':uid', $_POST['userID']);
			$stmt2->bindParam(':gn', $_POST['gameName']);
			$stmt2->bindParam(':hs', $_POST['highScore']);
			$stmt2->bindParam(':tp', $_POST['timesPlayed']);
			$stmt2->bindParam(':ds', $_POST['description']);
			$stmt2->execute();
		}
  
  
  ?>