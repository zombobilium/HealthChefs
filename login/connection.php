<?php
  $db = new PDO('pgsql:host=localhost;dbname=postgres', 'postgres', 'mASTER'); //FIXME
  $db->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);
  $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

  $db->exec('SET SCHEMA \'public\''); //FIXME?
?>